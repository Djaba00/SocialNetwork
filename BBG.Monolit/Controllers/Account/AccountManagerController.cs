using AutoMapper;
using BBG.Controllers;
using BBG.Monolit.Models.Entities;
using BBG.Monolit.Models.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BBG.Monolit.Controllers.Account
{
    public class AccountManagerController : Controller
    {
        private IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountManagerController(IMapper mapper, UserManager<User> userManager,  SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View("Home/Login");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [Route("Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var findUser = await _userManager.FindByEmailAsync(model.Email);

                var user = _mapper.Map<User>(findUser);

                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);

                if(result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("UserPage", "AccountManager");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }

            return View("Views/Home/Index.cshtml", model);
        }

        [Route("UserPage")]
        [HttpGet]
        [Authorize]
        public IActionResult UserPage()
        {
            var user = User;

            var result = _userManager.GetUserAsync(user);

            return View("Views/UserPage/UserPage.cshtml", new UserViewModel(result.Result));
        }

        [Route("Logout")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
