using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayName("Serial#"), MaxLength(20)]
        public string SerialNo { get; set; }

        [Required]
        [DisplayName("Asset Tag"), MaxLength(20)]
        public string AssetTag { get; set; }
    }
}