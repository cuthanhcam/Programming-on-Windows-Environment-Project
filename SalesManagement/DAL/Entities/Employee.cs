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

        public string Phone { get; set; }

        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string Position { get; set; }

        public decimal? Salary { get; set; }

        public DateTime HireDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockTransaction> StockTransactions { get; set; }
    }
}
