using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWorkTask18
{
    public class InsertRecordsInOrderDetails
    {
        public void Excecute()
        {
            try
            {
                using(var context=new ContextClass())
                {
                    var order = new OrderDetail();
                    Console.WriteLine("enter orderQuantity");
                    order.orderQuantity = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("orderDiscount");
                    order.orderDiscount = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("enter productPrice");
                    order.productPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("enter productId");
                    order.productId = Convert.ToInt32(Console.ReadLine());

                    context.OrderDetails.Add(order);
                    context.SaveChanges();

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
