using AsaTeb.Application.Technologies.Repositories;
using AsaTeb.Domain.Technologies;
using AsaTeb.Persistence.Helpers;

namespace AsaTeb.Persistence.Technologies
{
    public class TechnologyRepository : ITechnologyRepository
    {

        public async Task<IEnumerable<Technology>?> LoadAllTechnologiesAsync()
        {
            var technologies = await HttpClientManager.ResolveUrl("api/technologies");
            var res = technologies?.Select(t => new Technology(t.Guid,t.Name));
            return res;
        }

        public async Task<Technology> GetTechnologyByIdAsync<T>(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
