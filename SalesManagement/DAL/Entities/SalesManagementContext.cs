using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Entities
{
    public partial class SalesManagementContext : DbContext
    {
        public SalesManagementContext()
            : base("name=SalesManagementContext")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StockTransaction> StockTransactions { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Cấu hình cho bảng Customers
            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.MembershipLevel)
                .HasMaxLength(50)
                .IsOptional();

            modelBuilder.Entity<Customer>()
                .Property(e => e.CreatedAt)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(e => e.UpdatedAt)
                .IsRequired();

            // Cấu hình cho bảng Employees
            modelBuilder.Entity<Employee>()
                .Property(e => e.Role)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Username)
                .HasMaxLength(50)
                .IsOptional();

            modelBuilder.Entity<Employee>()
                .Property(e => e.PasswordHash)
                .IsOptional();

            modelBuilder.Entity<Employee>()
                .Property(e => e.CreatedAt)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.UpdatedAt)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.EmployeeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.StockTransactions)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            // Cấu hình cho bảng Products
            modelBuilder.Entity<Product>()
                .Property(e => e.Category)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(e => e.Model)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(e => e.Brand)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(e => e.OriginalPrice)
                .HasPrecision(18, 2)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 2)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(e => e.StockQuantity)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(e => e.CreatedAt)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(e => e.UpdatedAt)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.StockTransactions)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            // Cấu hình cho bảng Orders
            modelBuilder.Entity<Order>()
                .Property(e => e.TotalAmount)
                .HasPrecision(18, 2)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(e => e.Discount)
                .HasPrecision(18, 2)
                .IsOptional();

            modelBuilder.Entity<Order>()
                .Property(e => e.Status)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(e => e.CreatedAt)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(e => e.UpdatedAt)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            // Cấu hình cho bảng OrderDetails
            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Quantity)
                .IsRequired();

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 2)
                .IsRequired();

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Price)
                .HasPrecision(18, 2)
                .IsRequired();

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.CreatedAt)
                .IsRequired();

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.UpdatedAt)
                .IsRequired();

            // Cấu hình cho bảng StockTransactions
            modelBuilder.Entity<StockTransaction>()
                .Property(e => e.TransactionType)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<StockTransaction>()
                .Property(e => e.Quantity)
                .IsRequired();

            modelBuilder.Entity<StockTransaction>()
                .Property(e => e.TransactionDate)
                .IsRequired();

            modelBuilder.Entity<StockTransaction>()
                .Property(e => e.CreatedAt)
                .IsRequired();

            modelBuilder.Entity<StockTransaction>()
                .Property(e => e.UpdatedAt)
                .IsRequired();
        }
    }
}