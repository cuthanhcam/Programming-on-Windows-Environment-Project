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
                return _context.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving products: " + ex.Message);
            }
        }

        // Thêm sản phẩm mới
        public void AddProduct(string category, string model, string brand, decimal price, int stockQuantity, string specifications, string imagePath, int promotion, int warranty)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(brand))
                    throw new ArgumentException("Category, Model, and Brand are required fields.");
                if (price <= 0) throw new ArgumentException("Price must be greater than zero.");
                if (stockQuantity < 0) throw new ArgumentException("Stock Quantity cannot be negative.");

                var newProduct = new Product
                {
                    Category = category,
                    Model = model,
                    Brand = brand,
                    Price = price,
                    StockQuantity = stockQuantity,
                    Specifications = specifications,
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

        // Cập nhật sản phẩm
        public void UpdateProduct(int productId, string details)
        {
            try
            {
                var product = _context.Products.Find(productId);
                if (product == null)
                    throw new Exception("Product not found.");

                // Phân tích dữ liệu từ details và cập nhật
                var lines = details.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    var parts = line.Split(':');
                    if (parts.Length < 2) continue;

                    var key = parts[0].Trim();
                    var value = parts[1].Trim();

                    switch (key)
                    {
                        case "Category":
                            product.Category = value;
                            break;
                        case "Model":
                            product.Model = value;
                            break;
                        case "Brand":
                            product.Brand = value;
                            break;
                        case "Price":
                            if (decimal.TryParse(value, out decimal price))
                                product.Price = price;
                            break;
                        case "Quantity":
                            if (int.TryParse(value, out int quantity))
                                product.StockQuantity = quantity;
                            break;
                        case "Promotion":
                            if (int.TryParse(value, out int promotion))
                                product.Promotion = promotion;
                            break;
                        case "Warranty":
                            if (int.TryParse(value, out int warranty))
                                product.Warranty = warranty;
                            break;
                        case "Specifications":
                            product.Specifications = value;
                            break;
                    }
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating product: " + ex.Message);
            }
        }

        // Xóa sản phẩm
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

        // Tìm kiếm theo loại sản phẩm
        public List<Product> GetProductsByCategory(string category)
        {
            try
            {
                return _context.Products.Where(p => p.Category == category).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving products by category: " + ex.Message);
            }
        }

        // Lọc theo thương hiệu
        public List<Product> GetProductsByBrand(string brand)
        {
            try
            {
                return _context.Products.Where(p => p.Brand == brand).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving products by brand: " + ex.Message);
            }
        }

        // Cập nhật ảnh sản phẩm
        public void UpdateProductImage(int productId, string imagePath)
        {
            try
            {
                var product = _context.Products.Find(productId);
                if (product != null)
                {
                    product.Image = imagePath;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating product image: " + ex.Message);
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
    }
}
