using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intandoyesizwe.Models.View_Models
{
    public class ParentVM
    {
        [Required(ErrorMessage = "Please choose Title.")]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Required(ErrorMessage = "Provide your initials.")]
        [MaxLength(3), MinLength(1)]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Spaces, special characters & numbers are not allowed.")]
        [Display(Name = "Initials")]
        public string initials { get; set; }

        [Required(ErrorMessage = "Surname cannot be empty.")]
        [MaxLength(50), MinLength(2)]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "special characters & numbers not allowed on {0}.")]
        [Display(Name = "Surname")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "First Name cannot be empty.")]
        [MaxLength(50), MinLength(2)]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Special characters & numbers are not allowed on {0}")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Display(Name = "ID No.")]
        [RSAIDNumber(ErrorMessage = "A valid ID Number is required.")]
        public string idNo { get; set; }

        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Required(ErrorMessage = "Enter parent's occupation.")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Special characters & numbers are not allowed on {0}")]
        [Display(Name = "Occupation")]
        public string occupation { get; set; }

        [Required(ErrorMessage = "Learner resides with this parent?")]
        [Display(Name = "Resides together?")]
        public string resideswith { get; set; }

        [Required(ErrorMessage = "Choose relationship to learner.")]
        [Display(Name = "Learner Relationship")]
        public string relationship { get; set; }

        [Required(ErrorMessage = "Enter number of other Children at this School.")]
        [Display(Name = "Number of Other Children:")]
        public int numberOfOtherChildren { get; set; }

        [Required(ErrorMessage = "Specify Learner's Position in the Family(e.g first)")]
        [Display(Name = "Learner Position")]
        public string familyPosition { get; set; }
    }
}