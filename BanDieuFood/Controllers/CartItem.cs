using BanDieuFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanDieuFood.Controllers
{
    public class CartItem
    {
        public Product product { get; set; }
        public int amount { get; set; }
        public decimal TotalMoney => amount * product.Price.Value;
    }
}