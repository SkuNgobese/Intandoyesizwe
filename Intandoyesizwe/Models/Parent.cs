using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intandoyesizwe.Models
{
    public class Parent
    {
        [Key, ForeignKey("AdmissionApplication")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Initials")]
        public string initials { get; set; }

        [Display(Name = "Surname")]
        public string lastName { get; set; }

        [Display(Name = "First Name")]
        public string firstName { get; set; }

        public string fullName
        {
            get
            {
                return title + " " + firstName  + " " + lastName;
            }
        }

        [Display(Name = "ID No.")]
        public string idNo { get; set; }

        //[Display(Name = "Gender")]
        //public string gender { get; set; }

        [Display(Name = "Occupation")]
        public string occupation { get; set; }

        [Display(Name = "Resides together?")]
        public string resideswith { get; set; }

        [Display(Name = "Learner Relationship")]
        public string relationship { get; set; }

        [Display(Name = "Number of Children:")]
        public int numberOfOtherChildren { get; set; }

        [Display(Name = "Learner Position")]
        public string familyPosition { get; set; }

        public virtual AdmissionApplication AdmissionApplication { get; set; }
    }
}