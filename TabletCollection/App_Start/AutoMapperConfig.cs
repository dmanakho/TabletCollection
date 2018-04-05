using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TabletCollection.Models;
using TabletCollection.ViewModels;
using TabletCollection.Infrastructure;

namespace TabletCollection
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentViewModel>();
            CreateMap<StudentViewModel, Student>();

            CreateMap<Tablet, TabletViewModel>()
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn.HasValue ? src.CreatedOn.Value.ToLocalTime() : src.CreatedOn))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn.HasValue ? src.UpdatedOn.Value.ToLocalTime() : src.UpdatedOn));
            CreateMap<TabletViewModel, Tablet>()
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn.HasValue ? src.CreatedOn.Value.ToUniversalTime() : src.CreatedOn))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn.HasValue ? src.UpdatedOn.Value.ToUniversalTime() : src.UpdatedOn));


            CreateMap<Collection, CollectionViewModel>()
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn.HasValue ? src.CreatedOn.Value.ToLocalTime() : src.CreatedOn))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn.HasValue ? src.UpdatedOn.Value.ToLocalTime() : src.UpdatedOn))
                .ConstructUsing(c => new CollectionViewModel());
            CreateMap<CollectionViewModel, Collection>()
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn.HasValue ? src.CreatedOn.Value.ToUniversalTime() : src.CreatedOn))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn.HasValue ? src.UpdatedOn.Value.ToUniversalTime() : src.UpdatedOn));

            CreateMap<Collection, BFFViewModel>()
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn.HasValue ? src.CreatedOn.Value.ToLocalTime() : src.CreatedOn))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn.HasValue ? src.UpdatedOn.Value.ToLocalTime() : src.UpdatedOn));
            CreateMap<BFFViewModel, Collection>()
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn.HasValue ? src.CreatedOn.Value.ToUniversalTime() : src.CreatedOn))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => src.UpdatedOn.HasValue ? src.UpdatedOn.Value.ToUniversalTime() : src.UpdatedOn));

        }
    }
}