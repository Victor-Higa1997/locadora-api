using AutoMapper;
using locadora_api.Dtos;

namespace locadora_api.Models.Profiles;
public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
       CreateMap<Filme, FilmeDto>().ReverseMap();
        CreateMap<Filme, patchFilmeDto>().ReverseMap();
    }
}


