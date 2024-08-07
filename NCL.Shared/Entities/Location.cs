using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NCL.Shared.Entities
{
    //model for Location
    public class Location
    {
        [Key] public int Location__ID { get; set; }

        [Required(ErrorMessage = "Location Name required.")]
        public string? Location__Name { get; set; }
    }

    //sub model extended from Location
    public class Location_Guest : Location
    {
        public List<VisitorActivity> VisitorActivities { get; set; }
    }

    public class Location_Video : Location
    {
        public List<Video> Videos { get; set; }
    }
}
