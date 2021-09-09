using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intandoyesizwe.Models
{
    public class PhysicalAddress
    {
        public PhysicalAddress()
        {

        }
        [Key, ForeignKey("AdmissionApplication")]
        public int Id { get; set; }

        [Display(Name = "Street")]
        public string street { get; set; }

        [Display(Name = "Suburb")]
        public string suburb { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }

        [Display(Name = "Area Code")]
        public string code { get; set; }

        public virtual AdmissionApplication AdmissionApplication { get; set; }
    }
}