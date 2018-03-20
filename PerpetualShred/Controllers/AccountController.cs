using Microsoft.AspNetCore.Mvc;
using PerpetualShred.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using PerpetualShred.Models;

namespace PerpetualShred.Controllers
{
    public class AccountController : Controller
    {
        //Construction
        private readonly UserManager<ShredIdentityUser> userManager;
        private readonly SignInManager<ShredIdentityUser> signInManager;

        public AccountController(
            SignInManager<ShredIdentityUser> signInManager,
            UserManager<ShredIdentityUser> userManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        
        // Login/Logout/Uh-uh-nope
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await this.signInManager.PasswordSignInAsync(
                model.Username, model.Password, 
                isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError(string.Empty, "Login Failed");
            return View(model);
        }
        
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
        
    }
}