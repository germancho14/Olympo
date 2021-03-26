using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Olympo.API.Models;

namespace Olympo.API.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(ILogger<RegisterController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserViewModel userViewModel)
        {
            _logger.LogDebug($"Foo {userViewModel.Email}");
            return View();
        }

        [HttpPost]
        [HttpGet]
        public IActionResult VerifyEmail(string email)
        {
            _logger.LogDebug("Entre!!");
            return Json(false);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
