using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCL.Shared.Entities
{
    //model for Employee
    public class Employee
    {
        [Key] public int Employee__ID { get; set; }

        [Required(ErrorMessage = "Employee Name required.")]
        public string? Employee__Name { get; set; }

        public DateTime? Employee__Log { get; set; } = DateTime.Now;
    }

    //sub model extended from Employee
    public class Employee_Moment : Employee
    {
        public List<Moment> Moments { get; set; }
    }
}
