using AsaTeb.Application.Technologies.Dtos;

namespace AsaTeb.Application.FacadePattern
{
    public interface IAsaTebService
    {
        Task<IList<TechnologyDto>> GetAllTechnologies();
    }
}
