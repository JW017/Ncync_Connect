using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCL.Shared.Entities
{
    public class Page
    {
        [Key] public int Page__ID { get; set; }

        [Range(1, 1000, ErrorMessage = "Plaese enter the page sequence number.")]
        public int Page__SequenceNo { get; set; }

        public string Page__FolderPathName { get; set; }

        [Required(ErrorMessage = "Page Name First Line required.")]
        public string Page__Name { get; set; }

        public string? Page__SecondName { get; set; }
    }

    //sub model extended from Page
    public class Page_Class : Page
    {
        public List<Class> Classes { get; set; }
    }

}
