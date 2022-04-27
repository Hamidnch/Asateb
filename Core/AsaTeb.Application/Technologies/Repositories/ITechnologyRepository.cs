using AsaTeb.Application.Technologies.Dtos;
using AsaTeb.Domain.Technologies;

namespace AsaTeb.Application.Technologies.Repositories;

public interface ITechnologyRepository
{
    Task<IEnumerable<Technology>?> LoadAllTechnologiesAsync();
    Task<Technology> GetTechnologyByIdAsync<T>(Guid id);
}