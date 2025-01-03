namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Orders = new HashSet<Order>();
            StockTransactions = new HashSet<StockTransaction>();
        }

        public int EmployeeID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression("^(Admin|Staff)$", ErrorMessage = "Role must be either 'Admin' or 'Staff'.")]
        public string Role { get; set; }

        public decimal? Salary { get; set; }

        public DateTime HireDate { get; set; }

        [StringLength(50)]
        [Index(IsUnique = true)] // Tạo chỉ mục duy nhất cho Username
        public string Username { get; set; }

        public string PasswordHash { get; set; } // Mật khẩu mã hóa (có thể NULL)

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockTransaction> StockTransactions { get; set; }
    }
}