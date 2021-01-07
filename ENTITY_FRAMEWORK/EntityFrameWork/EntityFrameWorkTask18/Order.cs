using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameWorkTask18
{
    public class OrderDetail
    {
        [Key]
        public int orderId { get; set; }
        public int orderQuantity { get; set; }
        public decimal orderDiscount { get; set; }
        public decimal productPrice { get; set; }
       
        public int productId { get; set; }

        public Product Product { get; set; }

    }
}
