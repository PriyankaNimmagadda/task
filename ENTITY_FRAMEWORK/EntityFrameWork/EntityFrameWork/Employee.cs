using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameWork
{
    public class Employee
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int empId { get; set; }


        public string empName { get; set; }
        public string empLoc { get; set; }

        public int deptId { get; set; } 
        public Department Department { get; set; }
    }
}
