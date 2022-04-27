using AsaTeb.Application.Candidates.Dtos;
using AsaTeb.Application.Candidates.Repositories;
using AsaTeb.Domain.Candidates;
using AutoMapper;
using MediatR;

namespace AsaTeb.Application.Candidates.Queries
{
    public record GetAllCandidatesQuery : IRequest<IEnumerable<CandidateDto>>
    {
        public record GetAllCandidatesQueryHandler : IRequestHandler<GetAllCandidatesQuery, IEnumerable<CandidateDto>>
        {
            private readonly ICandidateRepository _candidateRepository;
            private readonly IMapper _mapper;

            public GetAllCandidatesQueryHandler(ICandidateRepository candidateRepository, IMapper mapper)
            {
                _candidateRepository = candidateRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<CandidateDto>> Handle(GetAllCandidatesQuery request, CancellationToken cancellationToken)
            {
                var candidates = await _candidateRepository.LoadAllCandidatesAsync();
                
                if (candidates == null) return new List<CandidateDto>();

                var candidatesDto = 
                    candidates.Select(c => _mapper.Map<Candidate, CandidateDto>(c)).ToList();
                return candidatesDto;

            }
        }
    }
}
