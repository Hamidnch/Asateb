using AsaTeb.Application.Candidates.Dtos;
using AsaTeb.Application.Candidates.Repositories;
using AsaTeb.Application.Technologies.Repositories;
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
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;

            public GetAllCandidatesQueryHandler(ICandidateRepository candidateRepository, IMapper mapper, ITechnologyRepository technologyRepository)
            {
                _candidateRepository = candidateRepository;
                _mapper = mapper;
                _technologyRepository = technologyRepository;
            }

            public async Task<IEnumerable<CandidateDto>> Handle(GetAllCandidatesQuery request, CancellationToken cancellationToken)
            {
                var candidates = await _candidateRepository.LoadAllCandidatesAsync();
                
                if (candidates == null) return new List<CandidateDto>();

                var candidatesDto =
                    candidates.Select(c => //_mapper.Map<Candidate, CandidateDto>(c))
                            new CandidateDto()
                            {
                                FirstName = c.FirstName,
                                LastName = c.LastName,
                                Gender = c.GenderType,
                                ProfilePicture = c.ProfilePicture,
                                Email = c.Email,
                                FavoriteMusicGenre = c.FavoriteMusicGenre,
                                Dad = c.Dad,
                                Mom = c.Mom,
                                CanSwim = c.CanSwim,
                                Barcode = c.Barcode,
                                CandidateId = c.Id,
                                Experience = c.Experiences.Select(e => new ExperienceDto()
                                {
                                    TechnologyName =
                                        (_technologyRepository.GetTechnologyByIdAsync(e.TechnologyId)).Result?.Name,
                                    TechnologyId = e.TechnologyId,
                                    YearsOfExperience = e.YearsOfExperience
                                }).ToList()
                            })
                        .ToList();

                return candidatesDto;
            }
        }
    }
}
