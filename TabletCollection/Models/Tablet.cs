using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TabletCollection.Models
{
    public class Tablet : Auditable
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

        [DisplayName("Purchased and PickedUp")]
        public bool IsPickedUp { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

        public virtual ICollection<Collection> Collections { get; set; }
    }
}