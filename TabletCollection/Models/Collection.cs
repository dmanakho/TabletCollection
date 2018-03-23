using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TabletCollection.Models
{
    public class Collection : Auditable
    {
        public int Id { get; set; }
        public bool IsStylus { get; set; } 
        public bool IsAC { get; set; }
        public bool IsNegligence { get; set; }
        public string Comments { get; set; }
        
        public virtual Tablet Tablet { get; set; }
        public virtual Student Student { get; set; }
    }
}