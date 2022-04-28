using AsaTeb.Application.Technologies.Dtos;
using AsaTeb.Application.Technologies.Repositories;
using AsaTeb.Persistence.Helpers;

namespace AsaTeb.Persistence.Technologies
{
    public class TechnologyRepository : ITechnologyRepository
    {

        public async Task<IEnumerable<TechnologyDto>?> LoadAllTechnologiesAsync()
        {
            var technologies =
                await HttpClientManager.GetUrlAsync<IEnumerable<TechnologyRest>>("api/technologies");

            var res = technologies?.Select(t => new TechnologyDto { Guid = t.Guid, Name = t.Name });
            return res;
        }

        public async Task<TechnologyDto?> GetTechnologyByIdAsync(Guid id)
        {
            var technologies = await LoadAllTechnologiesAsync();
            var res = technologies?.FirstOrDefault(t => t.Guid == id);
            return res;

            //var technology =
            //    await HttpClientManager.GetUrlAsync<Technology>($"api/technologies/{id}");
            //return technology;
        }
    }
}
