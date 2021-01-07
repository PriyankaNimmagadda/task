using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameWorkTask18
{
   public class Product
    {
        [Key]
        public  int productId { get; set; }
        public string productName { get; set; }
        public  string productStock { get; set; }
        public decimal productPrice { get; set; }

        public ICollection<OrderDetail> OrderDetail { get; set; }

    }
}
