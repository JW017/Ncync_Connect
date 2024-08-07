using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCL.Shared.Entities
{
    public class Moment
    {
        [Key] public int Moment__ID { get; set; }

        [Required(ErrorMessage = "Moment Title required.")]
        public string? Moment__Title { get; set; }

        public string? Moment__FileType { get; set; }

        [Range(1, 1000, ErrorMessage = "Plaese enter a sequence number.")]
        public int Moment__SequenceNo { get; set; }

        public string? Moment__Description { get; set; }

        public DateTime Moment__DateTime { get; set; } = DateTime.Now;

        public string? Moment__FilePath { get; set; }

        [Required(ErrorMessage = "Please Update Moment Status.")]
        public string? Moment__Status { get; set; }

        public int EmployeeEmployee__ID { get; set; }
        public Employee? Employee { get; set; }
    }

}
