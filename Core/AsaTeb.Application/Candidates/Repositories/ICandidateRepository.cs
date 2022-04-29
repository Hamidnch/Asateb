using AsaTeb.Application.Candidates.Dtos;

namespace AsaTeb.Application.Candidates.Repositories;

public interface ICandidateRepository
{
    Task<IEnumerable<CandidateDto>?> LoadAllCandidatesAsync();
    Task<IEnumerable<CandidateDto>> GetCandidatesByTechnologyIdAsync(Guid technologyId);
    Task<IEnumerable<CandidateDto>?> FilterCandidatesAsync(CandidateByDto candidateByDto);
    Task<IEnumerable<ExperienceDto>> GetExperiencesByCandidateIdAsync(Guid candidateId);
}