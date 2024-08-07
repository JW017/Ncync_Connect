using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCL.Shared.Entities
{
    public class Event
    {
        [Key] public int Event__ID { get; set; }

        public int Event__SequenceNo { get; set; }

        public string Event__FolderPathName { get; set; }

        [Required(ErrorMessage = "Event Title required.")]
        public string Event__Title { get; set; }

        [Required(ErrorMessage = "Event Description required.")]
        public string Event__Description { get; set; }

        [Required(ErrorMessage = "File Description required.")]
        public string Event__FileDescription { get; set; }

        public string? Event__FilePath { get; set; }

        [Required(ErrorMessage = "File Type required.")]
        public string Event__FileType { get; set; }

        public bool Event__Thumbnail { get; set; }

        [Range(1, 1000, ErrorMessage = "Plaese enter the event file sequence number.")]
        public int Event__FileSequenceNo { get; set; }


        [Range(1, 1000, ErrorMessage = "Please select a Class.")]
        public int Event_Class__ID { get; set; }
        public Class? Class { get; set; }
    }


}
