using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using TabletCollection.Models;
using TabletCollection.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace TabletCollection.ViewModels
{
    public class CollectionViewModel
    {
        public CollectionViewModel()
        {
                
        }
        public CollectionViewModel(int studentID) :this()
        {
            var tabletFinder = new SingleStudentTabletMapper(StudentID);

            if (tabletFinder.TabletID.HasValue)
            {
                TabletID = tabletFinder.TabletID.Value;
                TabletName = tabletFinder.TabletName;
            }
        }

        public int Id { get; set; }

        public int TabletID { get; set; }

        [DisplayName("Tablet")]
        public string TabletName { get; set; }

        public int StudentID { get; set; }

        [DisplayName("Student")]
        public string StudentFullName { get; set; }

        [DisplayName("Stylus")]
        public bool IsStylus { get; set; }

        [DisplayName("AC")]
        public bool IsAC { get; set; }

        [DisplayName("Negligence")]
        public bool IsNegligence { get; set; }

        [DisplayName("Why Charged?")]
        public string ChargeNotes { get; set; }

        [DisplayName("Comments")]
        public string Comments { get; set; }


    }
}