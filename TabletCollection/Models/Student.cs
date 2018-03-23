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
        public int ID { get; set; }

        public string ImportID { get; set; }

        [Required]
        [DisplayName("First Name"), MaxLength(50)]
        public string FirstName { get; set; }

        [DisplayName("NickName"), MaxLength(50)]
        public string NickName { get; set; }

        [Required]
        [DisplayName("Last Name"), MaxLength(50)]
        public string LastName { get; set; }

        [DisplayName("Full Name")]
        public string FullName
        {
            get {
                var _name = String.IsNullOrEmpty(NickName) ? FirstName : NickName;
                return $"{_name} {LastName}";
            }
        }
        [Required]
        [DisplayName("Class Of")]
        public int ClassOf { get; set; }

        public virtual Collection Collection { get; set; }
    }
}