using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intandoyesizwe.Models.View_Models
{
    public class ContactEmailVM
    {
        [Required(ErrorMessage = "Please provide us with your Name"), Display(Name = "Your name")]
        public string FromName { get; set; }

        [Required(ErrorMessage = "Please enter your Email Address"), Display(Name = "Your email"), EmailAddress]
        public string FromEmail { get; set; }

        public string subject { get; set; }

        [Required(ErrorMessage = "You can't send empty Email!")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}