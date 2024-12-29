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
        public void AddProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding product: " + ex.Message);
            }
        }

        // Cập nhật sản phẩm
        public void UpdateProduct(Product product)
        {
            try
            {
                var existing = _context.Products.Find(product.ProductID);
                if (existing != null)
                {
                    _context.Entry(existing).CurrentValues.SetValues(product);
                    _context.SaveChanges();
                }
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
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                }
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
    }
}
