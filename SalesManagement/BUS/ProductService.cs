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
            using (var _context = new SalesManagementContext())
            {
                return _context.Products.ToList();
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

                // Tính toán giá gốc từ giá sau khuyến mãi và phần trăm khuyến mãi
                decimal originalPrice = (promotion == 0) ? price : (price * 100) / (100 - promotion);

                // Tạo sản phẩm mới
                var newProduct = new Product
                {
                    Category = category,
                    Model = model,
                    Brand = brand,
                    OriginalPrice = originalPrice, // Lưu giá gốc
                    Price = price, // Giá sau khuyến mãi
                    StockQuantity = 0, // Mặc định số lượng là 0
                    Specifications = specifications, // Lưu các thông số kỹ thuật khác
                    Image = imagePath,
                    Promotion = promotion,
                    Warranty = warranty,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _context.Products.Add(newProduct);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding product: " + ex.Message);
            }
        }

        public void UpdateProduct(int productId, string category, string model, string brand, decimal originalPrice, string specifications, string imagePath, int promotion, int warranty)
        {
            try
            {
                var product = _context.Products.Find(productId);
                if (product == null)
                    throw new Exception("Product not found.");

                // Tính toán giá gốc từ giá sau khuyến mãi và phần trăm khuyến mãi
                decimal price = originalPrice * (100 - promotion) / 100;

                // Cập nhật các trường chính
                product.Category = category;
                product.Model = model;
                product.Brand = brand;
                product.OriginalPrice = originalPrice;
                product.Price = price;
                product.Promotion = promotion;

                // Cập nhật các thông số kỹ thuật
                product.Specifications = specifications;

                // Cập nhật các trường khác
                product.Image = imagePath;
                product.Warranty = warranty;
                product.UpdatedAt = DateTime.Now;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi chi tiết
                throw new Exception("Error updating product: " + ex.Message + (ex.InnerException != null ? " Inner Exception: " + ex.InnerException.Message : ""));
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
        public List<Product> FilterProducts(string category, string brand, string searchText, string priceSort, int? productID = null)
        {
            try
            {
                var query = _context.Products.AsQueryable();

                // Lọc theo ProductID
                if (productID.HasValue)
                {
                    query = query.Where(p => p.ProductID == productID.Value);
                }

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
            catch (Exception)
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


        public void UpdateProduct(Product product)
        {
            try
            {
                var existingProduct = _context.Products.Find(product.ProductID);
                if (existingProduct == null)
                    throw new Exception("Product not found.");

                // Cập nhật số lượng sản phẩm
                existingProduct.StockQuantity = product.StockQuantity;
                existingProduct.UpdatedAt = DateTime.Now;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating product: " + ex.Message);
            }
        }

        public List<Product> GetProducts(string productID = null)
        {
            try
            {
                var query = _context.Products.AsQueryable();

                // Lọc theo ProductID nếu có
                if (!string.IsNullOrEmpty(productID))
                {
                    int id;
                    if (int.TryParse(productID, out id))
                    {
                        query = query.Where(p => p.ProductID == id);
                    }
                    else
                    {
                        // Nếu productID không phải số, trả về danh sách rỗng
                        return new List<Product>();
                    }
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving products: " + ex.Message);
            }
        }
        public void RefreshContext()
        {
            // Refresh the context to get latest data
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                entry.Reload();
            }
        }
    }
}
