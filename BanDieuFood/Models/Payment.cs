namespace BanDieuFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentID { get; set; }

        public int? UserID { get; set; }

        [StringLength(50)]
        public string PaymentMethod { get; set; }

        public DateTime? PaymentDate { get; set; }

        public bool? PaymentStatus { get; set; }

        public int? OrderID { get; set; }

        public virtual User User { get; set; }
    }
}
