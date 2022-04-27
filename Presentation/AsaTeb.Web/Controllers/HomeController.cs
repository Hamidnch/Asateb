using AsaTeb.Application.FacadePattern;
using Microsoft.AspNetCore.Mvc;

namespace AsaTeb.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAsaTebService _asaTebService;

        public HomeController(IAsaTebService asaTebService)
        {
            _asaTebService = asaTebService;
        }

        public async Task<IActionResult> Index()
        {
            var technologies = await _asaTebService.GetAllTechnologies();
            return View(technologies);
        }
    }
}
