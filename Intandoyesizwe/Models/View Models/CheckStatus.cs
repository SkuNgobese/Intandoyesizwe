using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intandoyesizwe.Models.View_Models
{
    public class CheckStatus
    {
        [Display(Name = "ID Number")]
        [RSAIDNumber(ErrorMessage = "A valid ID Number is required.")]
        [System.Web.Mvc.Remote("StudentIDDoesntExists", "AdmissionApplication", ErrorMessage = "ID Number does not exist.")]
        public string idNo { get; set; }
    }
}