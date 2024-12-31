namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StockTransaction
    {
        [Key]
        public int TransactionID { get; set; }

        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string TransactionType { get; set; }

        public int Quantity { get; set; }

        public DateTime TransactionDate { get; set; }

        public int EmployeeID { get; set; }

        public string Note { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Product Product { get; set; }
    }
}
