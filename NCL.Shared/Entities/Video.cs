using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCL.Shared.Entities
{

    //model for Video
    public class Video
    {
        [Key] public int Video__ID { get; set; }

        public string? Video__Path { get; set; }

        [Required(ErrorMessage = "Please enter a video name.")]
        public string? Video__Name { get; set; }

        [Range(1, 1000, ErrorMessage = "Please select the video location.")]
        public int LocationLocation__ID { get; set; }
        public Location? Location { get; set; }
    }

}
