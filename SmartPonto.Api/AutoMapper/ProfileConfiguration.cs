using AutoMapper;
using SmartPonto.Api.Dto;
using SmartPonto.Api.Models;

namespace SmartPonto.Api.AutoMapper
{
    public class ProfileConfiguration : Profile
    {
        public ProfileConfiguration()
        {
            CreateMap<Usuario,UsuarioDto>().ReverseMap();
            CreateMap<Login,LoginDto>().ReverseMap();
            CreateMap<Empresa,EmpresaDto>().ReverseMap();
        }
    }
}