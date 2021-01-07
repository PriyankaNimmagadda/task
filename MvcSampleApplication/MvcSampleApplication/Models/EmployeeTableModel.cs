using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSampleApplication.Models
{
    [Table("EmployeeTable")]
    public class EmployeeTableModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int empId { get; set; }
        public string empName { get; set; }
        public decimal empSalary { get; set; }
        public DateTime empDob { get; set; }

        

    }
}


