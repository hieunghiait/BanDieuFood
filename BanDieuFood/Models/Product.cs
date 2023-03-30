namespace BanDieuFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }
        [Required]
        [DisplayName("ID")]
        public int ProductID { get; set; }
        [Required]
        [DisplayName("Tên sản phẩm")]
        [MinLength(3), MaxLength(50)]
        public string ProductName { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Hình ảnh")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số lượng")]
        [DisplayName("Số lượng")]
        public int? Quantity { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá tiền")]
        [DisplayName("Giá tiền")]
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập đơn vị")]
        [MinLength(3),MaxLength(5)]
        [DisplayName("Đơn vị")]
        public string Unit { get; set; }
        
        public int? CategoryID { get; set; }

        public int? ShoppingCartID { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
