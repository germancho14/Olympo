using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Olympo.API.Models;
using Olympo.Domain.Entities;
using Olympo.Domain.Repositories;

namespace Olympo.API.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<RegisterController> _logger;
        private readonly IUserRepository _userRepository;

        public RegisterController(
            ILogger<RegisterController> logger,
            IUserRepository userRepository)
        {
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));            
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserViewModel userViewModel)
        {
            _logger.LogDebug($"Saving user {userViewModel.Email}");
            var user = new User(userViewModel.Email);
            user.FirstName = userViewModel.FirstName;
            user.LastName = userViewModel.LastName;
            user.Phone = userViewModel.Phone;
            await _userRepository.SaveAsync(user);
            return View();
        }

        [HttpPost]
        [HttpGet]
        public IActionResult VerifyEmail(string email)
        {
            _logger.LogDebug("Entre!!");
            return Json(true);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
