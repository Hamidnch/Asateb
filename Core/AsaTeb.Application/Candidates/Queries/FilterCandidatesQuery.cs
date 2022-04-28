using AsaTeb.Application.Candidates.Dtos;
using AsaTeb.Application.Candidates.Repositories;
using MediatR;

namespace AsaTeb.Application.Candidates.Queries
{
    public record FilterCandidatesQuery(CandidateByDto CandidateByDto) : IRequest<IEnumerable<CandidateDto>>
    {
        public record FilterCandidatesQueryHandler : IRequestHandler<FilterCandidatesQuery, IEnumerable<CandidateDto>>
        {
            private readonly ICandidateRepository _candidateRepository;

            public FilterCandidatesQueryHandler(ICandidateRepository candidateRepository)
            {
                _candidateRepository = candidateRepository;
            }

            public async Task<IEnumerable<CandidateDto>> Handle(FilterCandidatesQuery request, CancellationToken cancellationToken)
            {
                var candidates =
                    await _candidateRepository.FilterCandidatesAsync(request.CandidateByDto);

                return candidates ?? new List<CandidateDto>();
            }
        }
    }
}
