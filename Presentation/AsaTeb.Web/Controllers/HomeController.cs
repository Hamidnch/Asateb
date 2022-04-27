using AsaTeb.Application.Candidates.Dtos;
using AsaTeb.Application.FacadePattern;
using AsaTeb.Application.Technologies.Dtos;
using AsaTeb.WebFramework.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AsaTeb.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAsaTebService _asaTebService;
        private readonly IMapper _mapper;

        public HomeController(IAsaTebService asaTebService, IMapper mapper)
        {
            _asaTebService = asaTebService;
            _mapper = mapper;
        }

        public Task<IActionResult> Index()
        {
            return Task.FromResult<IActionResult>(View());
        }
        public async Task<IActionResult> GetAllTechnologies()
        {
            var technologies = await _asaTebService.GetAllTechnologiesAsync();
            var model =
                technologies.Select(t => _mapper.Map<TechnologyDto, TechnologyModel>(t));
            return View(model);
        }

        public async Task<IActionResult> GetAllCandidates()
        {
            var candidates = await _asaTebService.GetAllCandidatesAsync();
            var model = 
                candidates.Select(c => _mapper.Map<CandidateDto, CandidateModel>(c));
            return View(model);
        }
    }
}
