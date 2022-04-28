using AsaTeb.Application.Candidates.Dtos;
using AsaTeb.Domain.Candidates;

namespace AsaTeb.Application.Candidates.Repositories;

public interface ICandidateRepository
{
    Task<IEnumerable<CandidateDto>?> LoadAllCandidatesAsync();
    Task<IEnumerable<CandidateDto>> GetCandidatesByTechnologyIdAsync(Guid technologyId);
    Task<IEnumerable<ExperienceDto>> GetExperiencesByCandidateIdAsync(Guid candidateId);
}