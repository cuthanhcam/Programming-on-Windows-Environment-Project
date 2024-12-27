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
            return _context.Products.ToList();
        }

        // Thêm sản phẩm mới
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        // Cập nhật sản phẩm
        public void UpdateProduct(Product product)
        {
            var existing = _context.Products.Find(product.ProductID);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(product);
                _context.SaveChanges();
            }
        }

        // Xóa sản phẩm
        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        // Tìm kiếm theo loại sản phẩm
        public List<Product> GetProductsByCategory(string category)
        {
            return _context.Products.Where(p => p.Category == category).ToList();
        }

        // Lọc theo thương hiệu
        public List<Product> GetProductsByBrand(string brand)
        {
            return _context.Products.Where(p => p.Brand == brand).ToList();
        }
    }
}
