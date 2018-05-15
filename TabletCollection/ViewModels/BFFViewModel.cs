using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TabletCollection.DAL;
using System.ComponentModel;
using TabletCollection.Models;

namespace TabletCollection.ViewModels
{
    public class BFFViewModel : Auditable
    {
        public int Id { get; set; }

        public int TabletID { get; set; }

        [DisplayName("Tablet")]
        public string TabletTabletName { get; set; }

        [DisplayName("Serial#"), MaxLength(20)]
        public string TabletSerialNo { get; set; }

        [DisplayName("Asset Tag"), MaxLength(20)]
        public string TabletAssetTag { get; set; }

        [DisplayName("Purchased")]
        public bool TabletIsPurchased { get; set; }

        [DisplayName("Addtl. Purch.")]
        public bool TabletIsExtraPurchase { get; set; }

        [DisplayName("Tablet Notes"), MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string TabletNotes { get; set; }

        [DisplayName("PickedUp")]
        public bool TabletIsPickedUp { get; set; }

        [DisplayName("Lenovo Buyout")]
        public bool TabletIsVendorBuyout { get; set; }

        [DisplayName("Stylus")]
        public bool IsStylus { get; set; }

        [DisplayName("AC")]
        public bool IsAC { get; set; }

        [DisplayName("Negligence")]
        public bool IsNegligence { get; set; }

        [DisplayName("Reason for Negligence Charge")]
        [DataType(DataType.MultilineText)]
        public string ChargeNotes { get; set; }

        [DisplayName("Comments")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        public int StudentID { get; set; }

        [DisplayName("Student")]
        public string StudentFullName { get; set; }

        
        [DisplayName("User Name"), MaxLength(50)]
        public string StudentUserName { get; set; }

        [DisplayName("Exch. Trip")]
        public bool StudentForeignExchangeBound { get; set; }
        
        [DisplayName("Class Of")]
        public int? StudentClassOf { get; set; }

        [DisplayName("Stu. Notes")]
        public string StudentNotes { get; set; }



    }
}