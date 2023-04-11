using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;
        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var PiesOftheWeek = _pieRepository.PiesOfTheWeek;
            var homeViewModel = new HomeViewModel(PiesOftheWeek);
            return View(homeViewModel);
        }
    }
}
