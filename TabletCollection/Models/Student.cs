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

        [Required]
        [DisplayName("e-mail"), MaxLength(50)]
        public string UserName { get; set; }

        [DisplayName("Exch. Trip")]
        public bool ForeignExchangeBound { get; set; }

        [DisplayName("Full Name")]
        public string FullName
        {
            get {
                var _name = String.IsNullOrEmpty(NickName) ? FirstName : NickName;
                return $"{_name} {LastName}";
            }
        }
        [DisplayName("Class Of")]
        public int? ClassOf { get; set; }

        [DisplayName("Notes")]
        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        public virtual ICollection<Collection> Collections { get; set; }
    }
}