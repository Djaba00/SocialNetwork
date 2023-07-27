using BBG.Monolit.Models.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;

namespace BBG.Monolit.Controllers.Account
{
    public class RegisterController : Controller
    {
        [Route("Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View("/Home/Register");
        }

        [Route("RegisterStep2")]
        [HttpGet]
        public IActionResult RegisterStep2(RegisterViewModel registerViewModel)
        {
            return View("RegisterStep2", registerViewModel);
        }
    }
}
