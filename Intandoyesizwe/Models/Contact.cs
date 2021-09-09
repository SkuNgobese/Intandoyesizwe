using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intandoyesizwe.Models
{
    public class Contact
    {
        public Contact()
        {

        }
        [Key, ForeignKey("AdmissionApplication")]
        public int Id { get; set; }

        [Display(Name = "Home Number")]
        [DataType(DataType.PhoneNumber)]
        public string homeNo { get; set; }

        [Display(Name = "Emergency Number")]
        [DataType(DataType.PhoneNumber)]
        public string emergNo { get; set; }

        [Display(Name = "Learner Cell")]
        [DataType(DataType.PhoneNumber)]
        public string learnerNo { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Home Language")]
        public string homeLanguage { get; set; }

        [Display(Name = "Deceased Parent(s)")]
        public string deceasedParent { get; set; }

        [Display(Name = "Transport Mode")]
        public string transportMode { get; set; }

        public virtual AdmissionApplication AdmissionApplication { get; set; }
    }
}