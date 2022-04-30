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
        private static IEnumerable<CandidateRest>? FilterByYearsOfExperience(CandidateByDto candidateByDto,
            IEnumerable<CandidateRest>? candidatesRest)
        {
            if (candidateByDto.OperatorId >= 0)
            {
                candidatesRest = candidateByDto.OperatorId switch
                {
                    1 => candidatesRest?.Where(c =>
                        c.Experience.All(e => e.YearsOfExperience == candidateByDto.YearsOfExperience)),
                    2 => candidatesRest?.Where(c =>
                        c.Experience.All(e => e.YearsOfExperience >= candidateByDto.YearsOfExperience)),
                    3 => candidatesRest?.Where(c =>
                        c.Experience.All(e => e.YearsOfExperience <= candidateByDto.YearsOfExperience)),
                    4 => candidatesRest?.Where(c =>
                        c.Experience.All(e => e.YearsOfExperience > candidateByDto.YearsOfExperience)),
                    5 => candidatesRest?.Where(c =>
                        c.Experience.All(e => e.YearsOfExperience < candidateByDto.YearsOfExperience)),
                    _ => candidatesRest
                };
            }

            return candidatesRest;
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

            var query = candidates;

            if (query != null)
            {
                if (candidateByDto.TechnologyId != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
                {
                    query = query.Where(c =>
                        c.Experience.Any(e => e.TechnologyId == candidateByDto.TechnologyId));

                    query = FilterByYearsOfExperience(candidateByDto, query);
                }
            }
            
            query = query?.ToList();
            var technologiesRest = technologies?.ToList();

            if (query == null)
                return new List<CandidateDto>();

            if (technologiesRest == null)
                return query.Select(t => _mapper.Map<CandidateRest, CandidateDto>(t)).ToList();
        
            foreach (var c in query)
            {
                foreach (var e in c.Experience)
                {
                    foreach (var t in technologiesRest.Where(t => e.TechnologyId == t.Guid))
                    {
                        e.TechnologyName = t.Name;
                    }
                }
            }

            var res = query.Select(t => _mapper.Map<CandidateRest, CandidateDto>(t)).ToList();
            return res;
        }

        public async Task<IEnumerable<ExperienceDto>> GetExperiencesByCandidateIdAsync(Guid candidateId)
        {
            throw new NotImplementedException();
        }
    }
}
