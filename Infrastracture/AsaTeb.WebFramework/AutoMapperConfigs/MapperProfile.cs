using AsaTeb.Application.Candidates;
using AsaTeb.Application.Technologies.Dtos;
using AsaTeb.Domain.Candidates;
using AsaTeb.Domain.Technologies;
using AsaTeb.WebFramework.Models;
using AutoMapper;

namespace AsaTeb.WebFramework.AutoMapperConfigs
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Technology, TechnologyDto>().ReverseMap();
            CreateMap<Candidate, CandidateDto>().ReverseMap();
            CreateMap<TechnologyDto, TechnologyModel>().ReverseMap();
        }
    }
}