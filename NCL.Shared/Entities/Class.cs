using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCL.Shared.Entities
{
    public class Class
    {
        [Key] public int Class__ID { get; set; }

        [Range(1, 1000, ErrorMessage = "Plaese enter the class sequence number.")]
        public int Class__SequenceNo { get; set; }

        public string Class__FolderPathName { get; set; }

        [Required(ErrorMessage = "Class Name required.")]
        public string Class__Name { get; set; }

        [Range(1, 1000, ErrorMessage = "Please select a page.")]
        public int Class_Page__ID { get; set; }
        public Page? Page { get; set; }
    }

    //sub model extended from Class
    public class Class_Event : Class
    {
        public List<Event> Events { get; set; }
    }

}
