using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameWork
{
   public class Department
    {
        [Key]
        public int deptId { get; set; }
        public string deptName { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
