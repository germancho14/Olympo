using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Olympo.API.Models;
using Olympo.Domain.Entities;

namespace Olympo.API.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<RegisterController> _logger;
        private readonly UserService _userService;

        public RegisterController(
            ILogger<RegisterController> logger,
            UserService userService)
        {
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));            
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Success()
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
            user.Password = userViewModel.Password;
            await _userService.RegisterUserAsync(user);
            TempData["Register_Email"] = userViewModel.Email;
            return RedirectToAction("Success", "Register");
        }

        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> VerifyEmail(string email)
        {
            var existingUser = await _userService.IsExistingUserAsync(email);
            return Json(!existingUser);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
