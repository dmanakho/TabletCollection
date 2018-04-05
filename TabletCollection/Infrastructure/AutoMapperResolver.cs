using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TabletCollection.Models;
using TabletCollection.ViewModels;

namespace TabletCollection.Infrastructure
{
    public class UTCToLocalTimeResolver : IValueResolver<Tablet, TabletViewModel, DateTime?>
    {
        public DateTime? Resolve(Tablet tablet, TabletViewModel tabletViewModel, DateTime? destMember, ResolutionContext context)
        {
            return tablet.CreatedOn.HasValue ? tablet.CreatedOn.Value.ToLocalTime() : tablet.CreatedOn;
        }
    }
}