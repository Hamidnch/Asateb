using AsaTeb.Application.Candidates;
using AsaTeb.Application.Candidates.Dtos;
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
            CreateMap<Technology, TechnologyDto>()
                .ForMember(t => t.Guid,
                    d => 
                        d.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<TechnologyDto, TechnologyModel>()
                .ForMember(t => t.Id,
                    d => 
                        d.MapFrom(x => x.Guid))
                .ReverseMap();

            CreateMap<Candidate, CandidateDto>()
                .ForMember(c => c.CandidateId, 
                    dest => 
                        dest.MapFrom(map => map.Id))
                .ForMember(c => c.Experience,
                    dest =>
                        dest.MapFrom(map => map.Experiences))
                .ReverseMap();


            CreateMap<CandidateDto, CandidateModel>().ReverseMap();

            CreateMap<Experience, ExperienceDto>()
                .ForMember(c => c.TechnologyName,
                    dest=>dest.Ignore())

                //.ForPath(e => e.TechnologyName,
                //    dest =>
                //        dest.MapFrom(map => map.Technology.Name))
                .ReverseMap();

            CreateMap<ExperienceDto, ExperienceModel>().ReverseMap();

        }
    }
}