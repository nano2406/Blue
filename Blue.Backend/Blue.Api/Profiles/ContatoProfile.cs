using AutoMapper;
using Blue.Domain.Modelos;
using System;

namespace Blue.Api.Profiles
{
    public class ContatoProfile : Profile
    {
        public ContatoProfile()
        {
            CreateMap<ViewModels.Contato, Contato>().ReverseMap();

            CreateMap<ViewModels.ContatoForCreate, Contato>().ReverseMap();

            CreateMap<Guid, Contato>().
                ForMember(dest => dest.Id, opt => opt.MapFrom(src => src));

            CreateMap<ViewModels.ContatoForPatch, Contato>().ReverseMap();

        }
    }
}
