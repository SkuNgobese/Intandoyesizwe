using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intandoyesizwe.Models
{
    public class Rejected
    {
        [Key, ForeignKey("AdmissionApplication")]
        public int Id { get; set; }

        [Display(Name = "Reason")]
        [Required(ErrorMessage = "Please provide reason you want to reject this learner.")]
        [DataType(DataType.MultilineText)]
        public string reason { get; set; }

        public DateTime date_ { get; set; }

        public virtual AdmissionApplication AdmissionApplication { get; set; }
    }
}