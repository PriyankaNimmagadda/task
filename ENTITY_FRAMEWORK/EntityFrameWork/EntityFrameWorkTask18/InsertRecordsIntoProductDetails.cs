using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWorkTask18
{
   public class InsertRecordsIntoProductDetails
    {
        public void Execute()
        {
            try
            {
                using (var context = new ContextClass())
                {
                    var product = new Product();
                    //Console.WriteLine("enter the productId");
                    //product.productId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("enter productName");
                    product.productName = Console.ReadLine();
                    Console.WriteLine("enter productStock");
                    product.productStock = Console.ReadLine();
                    Console.WriteLine("enter productPrice");
                    product.productPrice = Convert.ToDecimal(Console.ReadLine());

                    context.ProductDetails.Add(product);
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
