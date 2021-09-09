using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intandoyesizwe.Models
{
    public class Personal
    {
        public Personal()
        {

        }
        [Key, ForeignKey("AdmissionApplication")]
        public int Id { get; set; }
        
        [Display(Name = "Surname")]
        public string surname { get; set; }
        
        [Display(Name = "Initials")]
        public string initials { get; set; }
        
        [Display(Name = "Nick Name")]
        public string nickname { get; set; }
        
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        
        [Display(Name = "Other Names")]
        public string otherNames { get; set; }

        public string fullName
        {
            get
            {
                return firstName + " " + otherNames + " " + surname;
            }
        }

        [Display(Name = "ID No.")]
        public string idNo { get; set; }

        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime dob { get; set; }

        [Display(Name = "Race")]
        public string race { get; set; }
        
        [Display(Name = "Dexterity")]
        public string dexterity { get; set; }

        [Display(Name = "Reg. Social Grant")]
        public string regSocGrant { get; set; }

        [Display(Name = "Rec. Social Grant")]
        public string recSocGrant { get; set; }

        public virtual AdmissionApplication AdmissionApplication { get; set; }
    }
}