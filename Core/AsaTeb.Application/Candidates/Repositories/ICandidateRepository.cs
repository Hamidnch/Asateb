using AsaTeb.Domain.Candidates;

namespace AsaTeb.Application.Candidates.Repositories;

public interface ICandidateRepository
{
    Task<IEnumerable<Candidate>?> LoadAllCandidatesAsync();
    Task<IEnumerable<Candidate>> GetCandidatesByTechnologyIdAsync(Guid technologyId);
    Task<IEnumerable<Experience>> GetExperiencesByCandidateIdAsync(Guid candidateId);
}