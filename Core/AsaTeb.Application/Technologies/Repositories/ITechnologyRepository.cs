using AsaTeb.Application.Technologies.Dtos;

namespace AsaTeb.Application.Technologies.Repositories;

public interface ITechnologyRepository
{
    Task<IEnumerable<TechnologyDto>?> LoadAllTechnologiesAsync();
    Task<TechnologyDto?> GetTechnologyByIdAsync(Guid id);
}