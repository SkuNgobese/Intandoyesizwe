using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intandoyesizwe.Models.View_Models
{
    public class PrevSchoolVM
    {
        [Required(ErrorMessage = "Provide previous school name.")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Special characters or numbers are not allowed.")]
        [Display(Name = "School Name")]
        public string schoolName { get; set; }

        [Required(ErrorMessage = "Select previous school province.")]
        [Display(Name = "Province")]
        public string province { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "Street address cannot contain special characters.")]
        [Display(Name = "Street")]
        public string street { get; set; }

        [Required(ErrorMessage = "Enter Suburb/Location.")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Suburb cannot contain numbers or special characters")]
        [Display(Name = "Suburb")]
        public string suburb { get; set; }

        [Required(ErrorMessage = "Please enter City/Town.")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "City cannot contain numbers or special characters.")]
        [Display(Name = "City")]
        public string city { get; set; }

        [Required(ErrorMessage = "Please enter Area Code.")]
        [StringLength(4, ErrorMessage = "Area Code is 4 digits long.", MinimumLength = 4)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Area Code cannot contain letters or special characters.")]
        [Display(Name = "Code")]
        public string code { get; set; }

        [Required(ErrorMessage = "Please choose Title.")]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Required(ErrorMessage = "Surname cannot be empty.")]
        [MaxLength(50), MinLength(2)]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "special characters & numbers not allowed on {0}.")]
        [Display(Name = "Surname")]
        public string lastName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "Cannot contain special characters.")]
        [Display(Name = "First Line")]
        public string firstLine { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Cannot contain numbers or special characters.")]
        [Display(Name = "Second Line")]
        public string postalCity { get; set; }

        [Required(ErrorMessage = "Enter Postal Code.")]
        [StringLength(4, ErrorMessage = "Postal Code is 4 digits long.", MinimumLength = 4)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Code cannot contain letters or special characters.")]
        [Display(Name = "Postal Code")]
        public string postalCode { get; set; }
    }
}