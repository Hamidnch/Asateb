using AsaTeb.Application.Candidates.Dtos;
using AsaTeb.Application.Technologies.Dtos;

namespace AsaTeb.Application.FacadePattern
{
    public interface IAsaTebService
    {
        Task<IEnumerable<TechnologyDto>> GetAllTechnologiesAsync();
        Task<TechnologyDto> GetTechnologyByIdAsync(Guid id);
        Task<IEnumerable<CandidateDto>> GetAllCandidatesAsync();
    }
}
