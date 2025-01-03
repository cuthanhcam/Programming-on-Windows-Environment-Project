using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ProductService
    {
        private readonly SalesManagementContext _context;
        public ProductService(SalesManagementContext context)
        {
            _context = context;
        }

        // Lấy toàn bộ danh sách sản phẩm
        public List<Product> GetAllProducts()
        {
            try
            {
                using (var _context = new SalesManagementContext())
                {
                    return _context.Products.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving products: " + ex.Message, ex);
            }
        }

        // Thêm sản phẩm mới
        public void AddProduct(string category, string model, string brand, decimal price, string specifications, string imagePath, int promotion, int warranty)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(brand))
                    throw new ArgumentException("Category, Model, and Brand are required fields.");
                if (price <= 0) throw new ArgumentException("Price must be greater than zero.");

                // Tạo sản phẩm mới
                var newProduct = new Product
                {
                    Category = category,
                    Model = model,
                    Brand = brand,
                    Price = price,
                    StockQuantity = 0, // Mặc định số lượng là 0
                    Specifications = specifications, // Lưu các thông số kỹ thuật khác
                    Image = imagePath,
                    Promotion = promotion,
                    Warranty = warranty
                };

                _context.Products.Add(newProduct);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding product: " + ex.Message);
            }
        }


        // Lấy sản phẩm theo ID
        public Product GetProductById(int productId)
        {
            try
            {
                return _context.Products.FirstOrDefault(p => p.ProductID == productId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving product by ID: " + ex.Message);
            }
        }
        // Lọc sản phẩm
        public List<Product> FilterProducts(string category, string brand, string searchText, string priceSort)
        {
            try
            {
                var query = _context.Products.AsQueryable();

                // Lọc theo Category
                if (!string.IsNullOrEmpty(category) && category != "All")
                {
                    query = query.Where(p => p.Category == category);
                }

                // Lọc theo Brand
                if (!string.IsNullOrEmpty(brand) && brand != "All")
                {
                    query = query.Where(p => p.Brand == brand);
                }

                // Tìm kiếm theo Model
                if (!string.IsNullOrEmpty(searchText))
                {
                    query = query.Where(p => p.Model.ToLower().Contains(searchText.ToLower()));
                }

                // Sắp xếp theo giá
                if (priceSort == "Price Ascending")
                {
                    query = query.OrderBy(p => p.Price);
                }
                else if (priceSort == "Price Descending")
                {
                    query = query.OrderByDescending(p => p.Price);
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error filtering products: " + ex.Message);
            }
        }


        public void UpdateProduct(int productId, string category, string model, string brand, decimal price, string specifications, string imagePath, int promotion, int warranty)
        {
            try
            {
                var product = _context.Products.Find(productId);
                if (product == null)
                    throw new Exception("Product not found.");

                // Cập nhật các trường chính
                product.Category = category;
                product.Model = model;
                product.Brand = brand;
                product.Price = price;

                // Cập nhật các thông số kỹ thuật
                product.Specifications = specifications;

                // Cập nhật các trường khác
                product.Image = imagePath;
                product.Promotion = promotion;
                product.Warranty = warranty;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating product: " + ex.Message);
            }
        }

        public void DeleteProduct(int productId)
        {
            try
            {
                var product = _context.Products.Find(productId);
                if (product == null)
                    throw new Exception("Product not found.");

                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting product: " + ex.Message);
            }
        }

        
        public List<string> GetAllBrands()
        {
            try
            {
                return _context.Products.Select(p => p.Brand).Distinct().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving brands: " + ex.Message);
            }
        }

        public List<string> GetAllCategories()
        {
            try
            {
                return _context.Products.Select(p => p.Category).Distinct().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving categories: " + ex.Message);
            }
        }

        public List<string> GetBrandsByCategory(string category)
        {
            try
            {
                return _context.Products
                    .Where(p => p.Category == category)
                    .Select(p => p.Brand)
                    .Distinct()
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving brands by category: " + ex.Message);
            }
        }
        public string GetEmptySpecifications(string category)
        {
            try
            {
                var specifications = GetDefaultSpecifications(category);
                StringBuilder sb = new StringBuilder();

                foreach (var spec in specifications)
                {
                    sb.AppendLine($"{spec}: ");
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return "Invalid specifications format.";
            }
        }
        public List<string> GetDefaultSpecifications(string category)
        {
            var specifications = new List<string>();

            switch (category)
            {
                case "Processor":
                    specifications.AddRange(new[] { "Cores", "Threads", "Socket Type", "Memory Speed", "Base Speed", "Turbo Speed", "Max Power Consumption" });
                    break;
                case "Motherboard":
                    specifications.AddRange(new[] { "Chipset", "Form Factor", "Socket Type", "Memory Slots", "Memory Type", "Memory Speed", "Storage Expansion", "Multi-GPU Support" });
                    break;
                case "CPU Cooler":
                    specifications.AddRange(new[] { "Fan RPM", "Noise Level", "Color" });
                    break;
                case "Case":
                    specifications.AddRange(new[] { "Side Panel", "Carbinet Type", "Color", "Motherboard Support", "Max GPU Length", "CPU Cooler Height", "Supported PSU Size" });
                    break;
                case "Graphic Card":
                    specifications.AddRange(new[] { "Memory", "Memory Interface", "Length", "Interface", "Chipset", "Max Power Consumption" });
                    break;
                case "RAM":
                    specifications.AddRange(new[] { "RAM Size", "Quantity", "RAM Type", "RAM Speed" });
                    break;
                case "Storage":
                    specifications.AddRange(new[] { "Capacity", "Type", "RPM", "Interface", "Cache Memory", "Form Factor" });
                    break;
                case "Case Cooler":
                    specifications.AddRange(new[] { "Fan RPM", "Airflow", "Noise Level" });
                    break;
                case "Power Supply":
                    specifications.AddRange(new[] { "Power", "Efficiency", "Color" });
                    break;
            }

            return specifications;
        }
        public void UpdateProductImage(int productId, string imagePath)
        {
            try
            {
                var product = _context.Products.Find(productId);
                if (product == null)
                    throw new Exception("Product not found.");

                product.Image = imagePath;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating product image: " + ex.Message);
            }
        }
    }
}
