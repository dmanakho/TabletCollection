using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using TabletCollection.Models;
using TabletCollection.Infrastructure;
using System.ComponentModel.DataAnnotations;
using TabletCollection.DAL;

namespace TabletCollection.ViewModels
{
    

    public class CollectionViewModel :Auditable, IValidatableObject
    {
        public CollectionViewModel()
        {
            IsStylus = true;
            IsAC = true;
            IsNegligence = false;
        }

        public CollectionViewModel(int studentID) :this()
        {
            var students = db.Students.Where(s => s.ID == studentID).Single(); ;
            StudentFullName = students.FullName;
            StudentID = students.ID;

            var tabletFinder = new SingleStudentTabletMapper(StudentID);

            if (tabletFinder.TabletID.HasValue)
            {
                TabletID = tabletFinder.TabletID.Value;
                TabletTabletName = tabletFinder.TabletName;
                TabletIsPurchased = tabletFinder.IsPurchased;
                TabletNotes = tabletFinder.Tablet.Notes;
            }

        }

        private TabletCollectionDBContext db = new TabletCollectionDBContext();

        public int Id { get; set; }

        public int TabletID { get; set; }

        [DisplayName("Tablet")]
        public string TabletTabletName { get; set; }

        [DisplayName("Fam. Purchased")]
        public bool TabletIsPurchased { get; set; }

        [DisplayName("Tablet Notes"), MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string TabletNotes { get; set; }

        public int StudentID { get; set; }

        [DisplayName("Student")]
        public string StudentFullName { get; set; }

        [DisplayName("Stylus")]
        public bool IsStylus { get; set; }

        [DisplayName("AC")]
        public bool IsAC { get; set; }

        [DisplayName("Negligence")]
        public bool IsNegligence { get; set; }

        [DisplayName("Reason for Negligence Charge"), MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string ChargeNotes { get; set; }

        [DisplayName("Comments"), MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //Don't have any custom validations... just throw a silly one.
            if (!String.IsNullOrEmpty(TabletTabletName) && TabletTabletName.Length > 500)
            {
                yield return new ValidationResult("Yo, that's a long name", new[] { "TabletID" });

            }
        }
    }
}