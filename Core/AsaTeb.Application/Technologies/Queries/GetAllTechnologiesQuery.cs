using AsaTeb.Application.Technologies.Dtos;
using AsaTeb.Application.Technologies.Repositories;
using AsaTeb.Domain.Technologies;
using AutoMapper;
using MediatR;

namespace AsaTeb.Application.Technologies.Queries
{
    public record GetAllTechnologiesQuery : IRequest<IEnumerable<TechnologyDto>>
    {
        public record GetAllTechnologiesQueryHandler : IRequestHandler<GetAllTechnologiesQuery, IEnumerable<TechnologyDto>>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;

            public GetAllTechnologiesQueryHandler(ITechnologyRepository technologyService, IMapper mapper)
            {
                _technologyRepository = technologyService;
                _mapper = mapper;
            }

            public async Task<IEnumerable<TechnologyDto>> Handle(GetAllTechnologiesQuery request, CancellationToken cancellationToken)
            {
                var technologies = await _technologyRepository.LoadAllTechnologiesAsync();

                if (technologies == null) return new List<TechnologyDto>();

                //var technologiesDto =
                //    technologies.Select(t => _mapper.Map<Technology, TechnologyDto>(t)).ToList();

                //return technologiesDto;

                return technologies;
            }
        }
    }
}
