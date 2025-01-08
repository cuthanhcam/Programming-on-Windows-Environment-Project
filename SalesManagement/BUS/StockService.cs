using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BUS
{
    public class StockService
    {
        private readonly SalesManagementContext _context;

        public StockService(SalesManagementContext context)
        {
            _context = context;
        }

        // Lấy tất cả giao dịch
        public List<StockTransaction> GetAllTransactions()
        {
            return _context.StockTransactions
                .Include(t => t.Product) // Include thông tin sản phẩm
                .Include(t => t.Employee) // Include thông tin nhân viên
                .ToList();
        }

        // Lọc giao dịch
        public List<StockTransaction> FilterTransactions(int? transactionID, DateTime startDate, DateTime endDate, string sortByDate)
        {
            var query = _context.StockTransactions
                .Include(t => t.Product) // Include thông tin sản phẩm
                .Include(t => t.Employee) // Include thông tin nhân viên
                .AsQueryable();

            // Lọc theo TransactionID
            if (transactionID.HasValue)
            {
                query = query.Where(t => t.TransactionID == transactionID.Value);
            }

            // Lọc theo ngày
            query = query.Where(t => t.TransactionDate >= startDate && t.TransactionDate <= endDate);

            // Sắp xếp theo ngày
            if (!string.IsNullOrEmpty(sortByDate))
            {
                if (sortByDate == "Ascending Date")
                {
                    query = query.OrderBy(t => t.TransactionDate);
                }
                else if (sortByDate == "Descending Date")
                {
                    query = query.OrderByDescending(t => t.TransactionDate);
                }
            }

            return query.ToList();
        }

        // Thực hiện giao dịch nhập hàng
        public void ImportProduct(int productID, int employeeID, int quantity, string note)
        {
            var product = _context.Products.Find(productID);
            if (product == null)
                throw new Exception("Product not found.");

            // Tăng số lượng tồn kho
            product.StockQuantity += quantity;

            // Tạo giao dịch nhập hàng
            var transaction = new StockTransaction
            {
                ProductID = productID,
                EmployeeID = employeeID,
                TransactionType = "Import",
                Quantity = quantity,
                TransactionDate = DateTime.Now,
                Note = note,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.StockTransactions.Add(transaction);
            _context.SaveChanges();
        }

        // Thực hiện giao dịch xuất hàng
        public void ExportProduct(int productID, int employeeID, int quantity, string note)
        {
            var product = _context.Products.Find(productID);
            if (product == null)
                throw new Exception("Product not found.");

            // Kiểm tra số lượng tồn kho
            if (product.StockQuantity < quantity)
                throw new Exception("Not enough stock.");

            // Giảm số lượng tồn kho
            product.StockQuantity -= quantity;

            // Tạo giao dịch xuất hàng
            var transaction = new StockTransaction
            {
                ProductID = productID,
                EmployeeID = employeeID,
                TransactionType = "Export",
                Quantity = quantity,
                TransactionDate = DateTime.Now,
                Note = note,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.StockTransactions.Add(transaction);
            _context.SaveChanges();
        }


        public void UpdateTransaction(int transactionID, int quantity, string note)
        {
            var transaction = _context.StockTransactions.Find(transactionID);
            if (transaction == null)
                throw new Exception("Transaction not found.");

            // Cập nhật số lượng và ghi chú
            transaction.Quantity = quantity;
            transaction.Note = note;
            transaction.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
        }
        public void DeleteTransaction(int transactionID)
        {
            var transaction = _context.StockTransactions.Find(transactionID);
            if (transaction == null)
                throw new Exception("Transaction not found.");

            _context.StockTransactions.Remove(transaction);
            _context.SaveChanges();
        }
    }
}
