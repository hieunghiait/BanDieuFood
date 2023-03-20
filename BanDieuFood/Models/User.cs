namespace BanDieuFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Orders = new HashSet<Order>();
            Payments = new HashSet<Payment>();
            UserGroup_Role = new HashSet<UserGroup_Role>();
        }

        public int UserID { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Vui lòng điền tài khoản")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Vui lòng điền mật khẩu")]
        [StringLength(20)]
        public string Password { get; set; }

        [StringLength(20)]
        public string confirmPassword { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public int? Phone { get; set; }

        public int? RoleID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserGroup_Role> UserGroup_Role { get; set; }
    }
}
