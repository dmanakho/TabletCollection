using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TabletCollection.Models;
using TabletCollection.ViewModels;

namespace TabletCollection
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentViewModel>();
            CreateMap<StudentViewModel, Student>();

            CreateMap<TabletViewModel, Tablet>().ReverseMap();

            CreateMap<Collection, CollectionViewModel>()
                .ConstructUsing(c=> new CollectionViewModel());
            CreateMap<CollectionViewModel, Collection>();
        }
    }
}