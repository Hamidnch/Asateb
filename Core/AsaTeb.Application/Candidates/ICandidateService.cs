namespace AsaTeb.Application.Candidates;

public interface ICandidateService
{
    Task LoadAllCandidates();
    Task<IList<CandidateDto>> GetCandidatesByTechnologyId(Guid technologyId);
    Task<IList<ExperienceDto>> GetExperiencesByCandidateId(Guid candidateId);
}