using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsaTeb.Application.Candidates.Dtos;
using AsaTeb.Application.Candidates.Repositories;
using AsaTeb.Application.Technologies.Dtos;
using AsaTeb.Domain.Candidates;
using AsaTeb.Domain.Technologies;
using AsaTeb.Persistence.Helpers;
using AutoMapper;

namespace AsaTeb.Persistence.Candidates
{
    public class CandidateRepository: ICandidateRepository
    {
        private readonly IMapper _mapper;

        public CandidateRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<Candidate>?> LoadAllCandidatesAsync()
        {
            var candidates = await HttpClientManager.ResolveUrlAsync<CandidateDto>("api/candidates");
            var res = candidates?.Select(t => _mapper.Map<CandidateDto, Candidate>(t)).ToList();
            return res;
        }

        public async Task<IEnumerable<Candidate>> GetCandidatesByTechnologyIdAsync(Guid technologyId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Experience>> GetExperiencesByCandidateIdAsync(Guid candidateId)
        {
            throw new NotImplementedException();
        }
    }
}
