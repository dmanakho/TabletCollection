using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TabletCollection.Models
{
    public class Student
    {
        [Required]
        [DisplayName("First Name"), MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name"), MaxLength(50)]
        public string LastName { get; set; }

        [DisplayName("Full Name")]
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        [Required]
        [DisplayName("Class Of")]
        public int ClassOf { get; set; }
    }
}