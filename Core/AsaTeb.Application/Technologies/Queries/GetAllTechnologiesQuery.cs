using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using AsaTeb.Application.Technologies.Dtos;
using AsaTeb.Application.Technologies.Repositories;
using AsaTeb.Domain.Technologies;
using AutoMapper;
using MediatR;

namespace AsaTeb.Application.Technologies.Queries
{
    public record GetAllTechnologiesQuery: IRequest<IList<TechnologyDto>>
    {
        public record GetAllTechnologiesQueryHandler: IRequestHandler<GetAllTechnologiesQuery, IList<TechnologyDto>>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;

            public GetAllTechnologiesQueryHandler(ITechnologyRepository technologyService, IMapper mapper)
            {
                _technologyRepository = technologyService;
                _mapper = mapper;
            }

            public async Task<IList<TechnologyDto>> Handle(GetAllTechnologiesQuery request, CancellationToken cancellationToken)
            {
                var technologies = await _technologyRepository.LoadAllTechnologiesAsync();
                
                var technologiesDto =
                    technologies.Select(t => _mapper.Map<Technology, TechnologyDto>(t)).ToList();

                return technologiesDto;
            }
        }
    }
}
