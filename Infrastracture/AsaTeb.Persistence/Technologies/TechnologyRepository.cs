using AsaTeb.Application.Technologies.Dtos;
using AsaTeb.Application.Technologies.Repositories;
using AsaTeb.Domain.Technologies;
using AsaTeb.Persistence.Helpers;

namespace AsaTeb.Persistence.Technologies
{
    public class TechnologyRepository : ITechnologyRepository
    {

        public async Task<IEnumerable<Technology>?> LoadAllTechnologiesAsync()
        {
            var technologies = 
                await HttpClientManager.GetUrlAsync<IEnumerable<TechnologyDto>>("api/technologies");
            var res = technologies?.Select(t => new Technology(t.Guid,t.Name));
            return res;
        }

        public async Task<Technology?> GetTechnologyByIdAsync(Guid id)
        {
            var technologies = await LoadAllTechnologiesAsync();
            var res = technologies?.FirstOrDefault(t => t.Id == id);
            return res;

            //var technology =
            //    await HttpClientManager.GetUrlAsync<Technology>($"api/technologies/{id}");
            //return technology;
        }
    }
}
