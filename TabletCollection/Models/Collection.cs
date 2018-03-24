using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TabletCollection.Models
{
    public class Collection : Auditable
    {
        public Collection()
        {
            IsStylus = true;
            IsAC = true;
            IsNegligence = false;
        }
        public int Id { get; set; }
        [DisplayName("Stylus")]
        public bool IsStylus { get; set; }

        [DisplayName("AC")]
        public bool IsAC { get; set; }

        [DisplayName("Negligence")]
        public bool IsNegligence { get; set; }

        [DisplayName("Notes")]
        public string ChargeNotes { get; set; }

        public string Comments { get; set; }

        public int TabletID { get; set; }
        public virtual Tablet Tablet { get; set; }

        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
    }
}