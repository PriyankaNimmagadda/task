using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSampleApplication.DependencyInjection
{
    public class DependencyInjectionClass : InterfaceClass
    {
       

        public string GetAge(DateTime dob)
        {
            var val = DateTime.Now.Subtract(dob);
            DateTime age = DateTime.MinValue + val;
            return string.Format("{0} years{1} months{2} days", age.Year - 1, age.Month - 1, age.Day - 1);
        }
    }
}
