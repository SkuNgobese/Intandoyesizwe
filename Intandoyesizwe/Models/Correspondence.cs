using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intandoyesizwe.Models
{
    public class Correspondence
    {
        [Key, ForeignKey("AdmissionApplication")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Surname")]
        public string lastName { get; set; }

        [Display(Name = "First Line")]
        public string firstLine { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }
        
        [Display(Name = "Postal Code")]
        public string code { get; set; }

        public virtual AdmissionApplication AdmissionApplication { get; set; }
    }
}