using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intandoyesizwe.Models.View_Models
{
    public class PersonalVM
    {

        [Display(Name = "Grade")]
        [Required(ErrorMessage = "Please enter Grade applying for.")]
        [Range(8, 11, ErrorMessage = "Grade can be between Grade 8 and 11.")]
        public int grade { get; set; }

        [Display(Name = "Highest Grade Passed")]
        [Required(ErrorMessage = "Please enter Highest Grade Passed.")]
        [Range(7, 11, ErrorMessage = "Grade can be between Grade 7 and 10.")]
        public int prevGrade { get; set; }

        [Required(ErrorMessage = "Please enter valid Year Grade was Passed."), Range(2015, 2018, ErrorMessage = "Please enter valid Year.")]
        [Display(Name = "Year")]
        public int prevGradeYear { get; set; }

        [Required(ErrorMessage = "Surname cannot be empty.")]
        [MaxLength(35), MinLength(3)]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Special characters & numbers are not allowed.")]
        [Display(Name = "Surname")]
        public string surname { get; set; }

        [Required(ErrorMessage = "Provide Initials.")]
        [MaxLength(3), MinLength(1)]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Spaces, special characters & numbers are not allowed.")]
        [Display(Name = "Initials")]
        public string initials { get; set; }

        [MaxLength(35), MinLength(3)]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Special characters & numbers are not allowed.")]
        [Display(Name = "Nick Name")]
        public string nickname { get; set; }

        [Required(ErrorMessage = "First name cannot be empty.")]
        [MaxLength(35), MinLength(3)]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Special characters & numbers are not allowed.")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [MaxLength(70), MinLength(3)]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Special characters & numbers are not allowed.")]
        [Display(Name = "Other Names")]
        public string otherNames { get; set; }

        [Display(Name = "ID No.")]
        [RSAIDNumber(ErrorMessage = "A valid ID Number is required.")]
        [System.Web.Mvc.Remote("StudentIDExists", "AdmissionApplication", ErrorMessage = "Your ID number already exists, please proceed to check Admission Status.")]
        public string idNo { get; set; }

        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }

        [Display(Name = "Race")]
        [Required(ErrorMessage = "Select Race.")]
        public string race { get; set; }

        [Required(ErrorMessage = "Select Dexterity.")]
        [Display(Name = "Dexterity")]
        public string dexterity { get; set; }

        [Required(ErrorMessage = "Registered for Social Grant?")]
        [Display(Name = "Reg. Social Grant")]
        public string regSocGrant { get; set; }

        [Required(ErrorMessage = "Receive Social Grant?")]
        [Display(Name = "Rec. Social Grant")]
        public string recSocGrant { get; set; }
    }
}