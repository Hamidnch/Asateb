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

        //public async Task<IActionResult> GetAllCandidates()
        //{
            //var candidates = await _asaTebService.GetAllCandidatesAsync();
            //var candidatesModel = 
            //    candidates.Select(c => _mapper.Map<CandidateDto, CandidateModel>(c));

            //var technologies = await _asaTebService.GetAllTechnologiesAsync();
            //var technologyDtos = technologies as TechnologyDto[] ?? technologies.ToArray();
            //var technologiesModel =
            //    //technologyDtos.Select(t=> _mapper.Map<TechnologyDto, TechnologyModel>(t));
            //    technologyDtos.Select(x => new SelectListItem
            //    {
            //        Value = x.Guid.ToString(),
            //        Text = x.Name
            //    }).ToList();

            //var criteriaModel = new CriteriaModel
            //{
            //    Technologies = technologiesModel,
            //    YearsOfExperiences = new List<SelectListItem>
            //    {
            //        new SelectListItem("1", "1"),
            //        new SelectListItem("2", "2"),
            //        new SelectListItem("3", "3"),
            //        new SelectListItem("4", "4"),
            //        new SelectListItem("5", "5"),
            //        new SelectListItem("6", "6"),
            //        new SelectListItem("7", "7"),
            //        new SelectListItem("8", "8"),
            //        new SelectListItem("9", "9"),
            //        new SelectListItem("10", "10")
            //    },
            //    Operators = new List<SelectListItem>
            //    {
            //        new SelectListItem("=" , "0"),
            //        new SelectListItem(">=", "1"),
            //        new SelectListItem("<=", "2"),
            //        new SelectListItem(">" , "3"),
            //        new SelectListItem("<" , "4")
            //    }
            //};

            //var model = new CatalogModel
            //{
            //    CandidatesModel = candidatesModel,
            //    CriteriaModel = criteriaModel
            //};

           // return View(model);
        //}

        //[HttpPost]
        public async Task<IActionResult> Filter(CriteriaModel criteriaModel)
        {
            var candidateByDto = new CandidateByDto
            {
                OperatorId = criteriaModel.Operator,
                TechnologyId = criteriaModel.TechnologyId,
                YearsOfExperience = criteriaModel.Year
            };

            var candidates = await _asaTebService.FilterCandidatesAsync(candidateByDto: candidateByDto);
            var candidatesModel =
                candidates.Select(c => _mapper.Map<CandidateDto, CandidateModel>(c));

            var technologies = await _asaTebService.GetAllTechnologiesAsync();
            var technologyDtos = technologies as TechnologyDto[] ?? technologies.ToArray();
            var technologiesModel =
                //technologyDtos.Select(t=> _mapper.Map<TechnologyDto, TechnologyModel>(t));
                technologyDtos.Select(x => new SelectListItem
                {
                    Value = x.Guid.ToString(),
                    Text = x.Name
                }).ToList();
            criteriaModel.Year = candidateByDto.YearsOfExperience;
            criteriaModel.Operator = candidateByDto.OperatorId;
            criteriaModel.TechnologyId = candidateByDto.TechnologyId;

            criteriaModel.Technologies = technologiesModel;
            criteriaModel.Operators = new List<SelectListItem>
            {
                new SelectListItem("=", "0"),
                new SelectListItem(">=", "1"),
                new SelectListItem("<=", "2"),
                new SelectListItem(">", "3"),
                new SelectListItem("<", "4")
            };
            criteriaModel.YearsOfExperiences = new List<SelectListItem>
            {
                new SelectListItem("1", "1"),
                new SelectListItem("2", "2"),
                new SelectListItem("3", "3"),
                new SelectListItem("4", "4"),
                new SelectListItem("5", "5"),
                new SelectListItem("6", "6"),
                new SelectListItem("7", "7"),
                new SelectListItem("8", "8"),
                new SelectListItem("9", "9"),
                new SelectListItem("10", "10")
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
