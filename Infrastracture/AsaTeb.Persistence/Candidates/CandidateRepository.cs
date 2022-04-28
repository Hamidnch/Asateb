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

        #region Private Methods

        private static async Task<IEnumerable<TechnologyRest>?> GetAllTechnologies()
        {
            return await HttpClientManager.GetUrlAsync<IEnumerable<TechnologyRest>>("api/technologies");
        }
        private static async Task<IEnumerable<CandidateRest>?> GetAllCandidates()
        {
            return await HttpClientManager.GetUrlAsync<IEnumerable<CandidateRest>>("api/candidates");
        }

        #endregion Private Methods

        public async Task<IEnumerable<CandidateDto>?> LoadAllCandidatesAsync()
        {
            //await HttpClientManager.GetUrlAsync<IEnumerable<TechnologyRest>>("api/technologies");
            //await HttpClientManager.GetUrlAsync<IEnumerable<CandidateRest>>("api/candidates");

            var technologies = await GetAllTechnologies();
            var candidates = await GetAllCandidates();

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

            var res = 
                candidatesRest?.Select(t => _mapper.Map<CandidateRest, CandidateDto>(t)).ToList();
            return res;
        }

        public async Task<IEnumerable<CandidateDto>> GetCandidatesByTechnologyIdAsync(Guid technologyId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CandidateDto>?> FilterCandidatesAsync(CandidateByDto candidateByDto)
        {
            var technologies = await GetAllTechnologies();
            var candidates = await GetAllCandidates();

            var candidatesRest = candidates;

            if (candidatesRest != null)
            {
                if (candidateByDto.TechnologyId != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
                {
                    candidatesRest = candidatesRest?.Where(c =>
                        c.Experience.Any(e => e.TechnologyId == candidateByDto.TechnologyId));

                    if (candidateByDto.OperatorId >= 0)
                    {
                        candidatesRest = candidateByDto.OperatorId switch
                        {
                            0 => candidatesRest?.Where(c =>
                                c.Experience.Any(e => e.YearsOfExperience == candidateByDto.YearsOfExperience)),
                            1 => candidatesRest?.Where(c =>
                                c.Experience.Any(e => e.YearsOfExperience >= candidateByDto.YearsOfExperience)),
                            2 => candidatesRest?.Where(c =>
                                c.Experience.Any(e => e.YearsOfExperience <= candidateByDto.YearsOfExperience)),
                            3 => candidatesRest?.Where(c =>
                                c.Experience.Any(e => e.YearsOfExperience > candidateByDto.YearsOfExperience)),
                            4 => candidatesRest?.Where(c =>
                                c.Experience.Any(e => e.YearsOfExperience < candidateByDto.YearsOfExperience)),
                            _ => candidatesRest
                        };
                    }
                }
            }
            
            candidatesRest = candidatesRest?.ToList();
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

            var res =
                candidatesRest?.Select(t => _mapper.Map<CandidateRest, CandidateDto>(t)).ToList();

            return res;
        }

        public async Task<IEnumerable<ExperienceDto>> GetExperiencesByCandidateIdAsync(Guid candidateId)
        {
            throw new NotImplementedException();
        }
    }
}
