using AsaTeb.Application.Technologies.Dtos;
using AsaTeb.Domain.Technologies;

namespace AsaTeb.Application.Technologies.Repositories;

public interface ITechnologyRepository
{
    Task<IEnumerable<TechnologyDto>?> LoadAllTechnologiesAsync();
    Task<TechnologyDto?> GetTechnologyByIdAsync(Guid id);
}