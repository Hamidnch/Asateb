using AsaTeb.Application.Candidates.Dtos;
using AsaTeb.Application.FacadePattern;
using AsaTeb.Application.Technologies.Dtos;
using AsaTeb.WebFramework.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        
        public async Task<IActionResult> Filter(CriteriaModel criteriaModel)
        {
            var candidateByDto = new CandidateByDto
            {
                OperatorId = criteriaModel.Operator,
                TechnologyId = criteriaModel.TechnologyId,
                YearsOfExperience = criteriaModel.Year
            };

            var candidates = 
                await _asaTebService.FilterCandidatesAsync(candidateByDto: candidateByDto);
            
            var candidatesModel =
                candidates.Select(c => _mapper.Map<CandidateDto, CandidateModel>(c));

            var technologies = await _asaTebService.GetAllTechnologiesAsync();
            
            var technologiesModel =
                technologies.Select(x => new SelectListItem
                {
                    Value = x.Guid.ToString(),
                    Text = x.Name,
                    Selected = candidateByDto.TechnologyId == x.Guid
                })
                    .ToList();

            criteriaModel.Technologies = technologiesModel;

            criteriaModel.Operators = new List<SelectListItem>
            {
                new(text: "=", value: "0", selected: candidateByDto.OperatorId == 1),
                new(text: ">=",value: "1", selected: candidateByDto.OperatorId == 2),
                new(text: "<=",value: "2", selected: candidateByDto.OperatorId == 3),
                new(text: ">", value: "3", selected: candidateByDto.OperatorId == 4),
                new(text: "<", value: "4", selected: candidateByDto.OperatorId == 5)
            };

            criteriaModel.YearsOfExperiences = new List<SelectListItem>
            {
                new(text: "1",value: "1", selected: candidateByDto.YearsOfExperience == 1),
                new(text: "2",value: "2", selected: candidateByDto.YearsOfExperience == 2),
                new(text: "3",value: "3", selected: candidateByDto.YearsOfExperience == 3),
                new(text: "4",value: "4", selected: candidateByDto.YearsOfExperience == 4),
                new(text: "5",value: "5", selected: candidateByDto.YearsOfExperience == 5),
                new(text: "6",value: "6", selected: candidateByDto.YearsOfExperience == 6),
                new(text: "7",value: "7", selected: candidateByDto.YearsOfExperience == 7),
                new(text: "8",value: "8", selected: candidateByDto.YearsOfExperience == 8),
                new(text: "9",value: "9", selected: candidateByDto.YearsOfExperience == 9),
                new(text: "10", "10")
            };

            var model = new CatalogModel
            {
                CandidatesModel = candidatesModel,
                CriteriaModel = criteriaModel
            };

            return View("GetAllCandidates", model);
        }
    }
}