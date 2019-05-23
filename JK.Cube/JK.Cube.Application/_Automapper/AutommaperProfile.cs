using AutoMapper;
using JK.Cube.Application.DomainEvents;
using JK.Cube.Application.Projections;
using JK.Cube.Domain.ValueObjects;

namespace JK.Cube.Application._Automapper
{
    public class AutommaperProfile : Profile
    {
        public AutommaperProfile()
        {
            CreateMap<DTO.Coordenate, Coordenate>();
            CreateMap<Coordenate, DTO.Coordenate>();

            CreateMap<CoordenateProjection, DTO.Coordenate>();
            CreateMap<DTO.Coordenate, CoordenateProjection>();

            CreateMap<CoordenateProjection, Coordenate>();
            CreateMap<Coordenate, CoordenateProjection>();

            CreateMap<DTO.Cube, Domain.Models.Cube>();
            CreateMap<Domain.Models.Cube, DTO.Cube>();

            CreateMap<CubeCreated, Domain.Models.Cube>();
            CreateMap<Domain.Models.Cube, CubeCreated>();

            CreateMap<CubeUpdated, Domain.Models.Cube>();
            CreateMap<Domain.Models.Cube, CubeUpdated>();

            CreateMap<CubeProjection, CubeUpdated>();
            CreateMap<CubeUpdated, CubeProjection>();

            CreateMap<Domain.Models.Cube, CubeProjection>();
            CreateMap<CubeProjection, Domain.Models.Cube>();

            CreateMap<CubeProjection, CubeCreated>();
            CreateMap<CubeCreated, CubeProjection>();
        }
    }
}
