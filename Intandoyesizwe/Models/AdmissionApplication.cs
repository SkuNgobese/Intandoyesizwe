using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intandoyesizwe.Models
{
    public class AdmissionApplication
    {
        public AdmissionApplication()
        {
            
        }
        public int Id { get; set; }

        [Display(Name = "Grade")]
        public int grade { get; set; }

        [Display(Name = "Year")]
        public int year { get; set; }

        [Display(Name = "Highest Grade Passed")]
        public int prevGrade { get; set; }

        [Display(Name = "Year")]
        public int prevGradeYear { get; set; }

        public DateTime date_ { get; set; }

        public bool status { get; set; }

        public virtual Personal Personal { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual PrevSchool PrevSchool { get; set; }
        public virtual Parent Parent { get; set; }
        public virtual Correspondence Correspondence { get; set; }
        public virtual PhysicalAddress PhysicalAddress { get; set; }
        public virtual Rejected Rejected { get; set; } 
    }
}