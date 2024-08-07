using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCL.Shared.Entities
{
    public class Visitor
    {
        [Key] public int Visitor__ID { get; set; }

        [Required(ErrorMessage = "Visitor Full Name required.")]
        public string? Visitor__Name { get; set; }

        [Required(ErrorMessage = "Visitor Contact required.")]
        public string? Visitor__Contact { get; set; }
    }

    public class VisitorActivity
    {
        [Key] public int VisitorActivity__ID { get; set; }

        public int VisitorVisitor__ID { get; set; }
        public Visitor? Visitor { get; set; }

        public DateTime VisitorActivity__DateTime { get; set; } = DateTime.Now;

        [Range(1, 1000, ErrorMessage = "Please select the visiting location.")]
        public int LocationLocation__ID { get; set; }
        public Location? Location { get; set; }
    }

    //sub model extended from Visitor
    public class Visitor_VisitorActivity : Visitor
    {
        public List<VisitorActivity> VisitorActivities { get; set; }
    }

}
