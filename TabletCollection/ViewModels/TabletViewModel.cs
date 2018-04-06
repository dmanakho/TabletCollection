using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TabletCollection.Models;

namespace TabletCollection.ViewModels
{
    public class TabletViewModel : Auditable
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Name"), MaxLength(50)]
        public string TabletName { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [DisplayName("Serial#"), MaxLength(20)]
        public string SerialNo { get; set; }

        [Required]
        [DisplayName("Asset Tag"), MaxLength(20)]
        public string AssetTag { get; set; }

        [DisplayName("Fam. Purchased")]
        public bool IsPurchased { get; set; }

        [DisplayName("Addtl. Purch.")]
        public bool IsExtraPurchase { get; set; }

        [DisplayName("Collected")]
        public bool IsTabletCollected { get; set; }

        [DisplayName("Picked Up")]
        public bool IsPickedUp { get; set; }

        [DisplayName("Notes"), MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        public int CollectionID { get; set; }
    }
}