using AsaTeb.Application.Technologies.Dtos;
using AsaTeb.Application.Technologies.Repositories;
using AutoMapper;
using MediatR;

namespace AsaTeb.Application.Technologies.Queries
{
    public record GetTechnologyByIdQuery(Guid Id) : IRequest<TechnologyDto>
    {
        public record GetTechnologyByIdQueryHandler : IRequestHandler<GetTechnologyByIdQuery, TechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            public GetTechnologyByIdQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
            }

            public async Task<TechnologyDto> Handle(GetTechnologyByIdQuery request, CancellationToken cancellationToken)
            {
                var res = await _technologyRepository.GetTechnologyByIdAsync(request.Id);
                return res ?? new TechnologyDto();
                //var technologyDto = _mapper.Map<Technology, TechnologyDto>(res);
                //return technologyDto;
            }
        }
    }
}
