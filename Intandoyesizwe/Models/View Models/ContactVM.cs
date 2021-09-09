using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intandoyesizwe.Models.View_Models
{
    public class ContactVM
    {
        [Required(ErrorMessage = "Enter home contact number, could be guardian/parent's number that you live with.")]
        [StringLength(10, ErrorMessage = "Home contact number must be 10 digits long.", MinimumLength = 10)]
        [Display(Name = "Home Number")]
        [DataType(DataType.PhoneNumber)]
        public string homeNo { get; set; }

        [Required(ErrorMessage = "Enter emergency contact number, could be guardian/parent's number.")]
        [StringLength(10, ErrorMessage = "Emergency contact number must be 10 digits long.", MinimumLength = 10)]
        [Display(Name = "Emergency Number")]
        [DataType(DataType.PhoneNumber)]
        public string emergNo { get; set; }

        [StringLength(10, ErrorMessage = "Learner cell number must be 10 digits long.", MinimumLength = 10)]
        [Display(Name = "Learner Cell")]
        [DataType(DataType.PhoneNumber)]
        public string learnerNo { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your home language.")]
        public string homeLanguage { get; set; }

        [Display(Name = "Deceased Parent(s)")]
        public string deceasedParent { get; set; }

        [Display(Name = "Transport Mode")]
        [Required(ErrorMessage = "Select your mode of transport.")]
        public string transportMode { get; set; }

        [Required(ErrorMessage = "Enter house number and street.")]
        [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "Street address cannot contain special characters.")]
        [Display(Name = "Street")]
        public string street { get; set; }

        [Required(ErrorMessage = "Enter Suburb/Location.")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Suburb cannot contain numbers or special characters.")]
        [Display(Name = "Suburb")]
        public string suburb { get; set; }

        [Required(ErrorMessage = "Enter City/Town.")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "City cannot contain numbers or special characters.")]
        [Display(Name = "City")]
        public string city { get; set; }

        [Required(ErrorMessage = "Enter Area Code.")]
        [StringLength(4, ErrorMessage = "Area Code is 4 digits long.", MinimumLength = 4)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Code cannot contain letters or special characters.")]
        [Display(Name = "Area Code")]
        public string code { get; set; }
    }
}