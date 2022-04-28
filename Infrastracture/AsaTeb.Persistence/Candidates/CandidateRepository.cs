using AsaTeb.Application.Candidates.Dtos;
using AsaTeb.Application.Candidates.Repositories;
using AsaTeb.Persistence.Helpers;
using AsaTeb.Persistence.Technologies;
using AutoMapper;

namespace AsaTeb.Persistence.Candidates
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly IMapper _mapper;

        public CandidateRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<CandidateDto>?> LoadAllCandidatesAsync()
        {
            var technologies = await HttpClientManager.GetUrlAsync<IEnumerable<TechnologyRest>>("api/technologies");
            var candidates = await HttpClientManager.GetUrlAsync<IEnumerable<CandidateRest>>("api/candidates");


            var candidatesRest = candidates?.ToList();

            var technologiesRest = technologies?.ToList();

            if (candidatesRest == null)
                return candidatesRest?.Select(t => _mapper.Map<CandidateRest, CandidateDto>(t)).ToList();

            foreach (var c in candidatesRest)
            {
                foreach (var e in c.Experience)
                {
                    if (technologiesRest == null) continue;

                    foreach (var t in technologiesRest.Where(t => e.TechnologyId == t.Guid))
                    {
                        e.TechnologyName = t.Name;
                    }
                }
            }

            var res = candidatesRest?.Select(t => _mapper.Map<CandidateRest, CandidateDto>(t)).ToList();
            return res;
        }

        public async Task<IEnumerable<CandidateDto>> GetCandidatesByTechnologyIdAsync(Guid technologyId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExperienceDto>> GetExperiencesByCandidateIdAsync(Guid candidateId)
        {
            throw new NotImplementedException();
        }
    }
}
