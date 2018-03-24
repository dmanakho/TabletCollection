using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TabletCollection.Models;

namespace TabletCollection.ViewModels
{
    public class StudentViewModel
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
        [DisplayName("User Name"), MaxLength(50)]
        public string UserName { get; set; }

        [DisplayName("Exch. Trip")]
        public bool ForeignExchangeBound { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Required]
        [DisplayName("Class Of")]
        public int? ClassOf { get; set; }

        public bool IsTabletCollected { get; set; }

        public int CollectionID { get; set; }
    }
}