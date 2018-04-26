using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PerpetualShred.Models;
using PerpetualShred.Models.AccountViewModels;
using PerpetualShred.Services;
using PerpetualShred.Data;
using PerpetualShred.ViewComponents;
using IdentityResult = Microsoft.AspNetCore.Identity.IdentityResult;

namespace PerpetualShred.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<ShredUser> _userManager;
        private readonly SignInManager<ShredUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly ShredUsersContext _context;
        private readonly PerpetualShredContext _vcontext;

        public AccountController(Microsoft.AspNetCore.Identity.UserManager<ShredUser> userManager,
            SignInManager<ShredUser> signInManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger,
            ShredUsersContext context,
            PerpetualShredContext vcontext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _context = context;
            _vcontext = vcontext;
        }

        [TempData] public string ErrorMessage { get; set; }

        [HttpGet]
        [AllowAnonymous]
        public bool IsLoggedIn()
        {
            return User.Identity.IsAuthenticated;
        }

        [HttpGet]
        [AllowAnonymous]
        public bool AddFav(string vidUrl)
        {
            if (User != null && User.Identity.IsAuthenticated)
            {
                using (var db = _context)
                {
                    var tempUser = db.ShredUser.Find(User.Identity.GetUserId());

                    if (tempUser.Favorites == null && vidUrl != null)
                    {
                        var newFavs = new List<string> {vidUrl};
                        string favJson = JsonConvert.SerializeObject(newFavs);
                        tempUser.Favorites = favJson;
                        db.ShredUser.Find(User.Identity.GetUserId()).Favorites = tempUser.Favorites;
                        db.SaveChanges();
                        return true;
                    }
                    else if (tempUser.Favorites != null && vidUrl != null)
                    {
                        if (tempUser.Favorites.Contains(vidUrl))
                        {
                            return false;
                        }
                        else
                        {
                            var favList = JsonConvert.DeserializeObject<List<string>>(tempUser.Favorites);
                            favList.Add(vidUrl);
                            string favJson = JsonConvert.SerializeObject(favList);
                            tempUser.Favorites = favJson;
                            db.ShredUser.Find(User.Identity.GetUserId()).Favorites = tempUser.Favorites;
                            db.SaveChanges();
                            return true;
                        }
                    }
                    else return false;
                }
            }
            else return false;
        }

        [HttpGet]
        [AllowAnonymous]
        public bool RemoveFav(string vidUrl)
        {
            if (User != null && User.Identity.IsAuthenticated)
            {
                using (var db = _context)
                {
                    var tempUser = db.ShredUser.Find(User.Identity.GetUserId());

                    if (tempUser.Favorites.Contains(vidUrl))
                    {
                        var favList = JsonConvert.DeserializeObject<List<string>>(tempUser.Favorites);
                        favList.RemoveAt(favList.FindIndex(x => x.Contains(vidUrl)));
                        string favJson = JsonConvert.SerializeObject(favList);
                        tempUser.Favorites = favJson;
                        db.ShredUser.Find(User.Identity.GetUserId()).Favorites = tempUser.Favorites;
                        db.SaveChanges();
                        return true;
                    }
                }
            }

            return false;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult UserFavs()
        {
            using (var db = _context)
            {
                string userFavs = db.ShredUser.Find(User.Identity.GetUserId()).Favorites;
                if (User.Identity.IsAuthenticated && userFavs != null)
                {
                    return ViewComponent("Favs", new {favString = userFavs});
                }
                else return View("Login");
            }
        }
        
        [HttpGet]
        [AllowAnonymous]
        public List<WebVid> GetFavObjects()
        {
            using (var db = _context)
            {
                string favString = db.ShredUser.Find(User.Identity.GetUserId()).Favorites;
                if (!User.Identity.IsAuthenticated || favString == null) return null;
                
                using (var vdb = _vcontext)
                {
                    var favList = JsonConvert.DeserializeObject<List<string>>(favString);
                    var webVidList = new List<WebVid>();
                    foreach (string vidUrl in favList)
                    {
                        var tempVid = vdb.WebVid.First(r => r.PlayerUrl.Contains(vidUrl));
                        webVidList.Add(tempVid);
                    }
                    return webVidList;
                }
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
// Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                if (!User.Identity.IsAuthenticated)
                {
// This doesn't count login failures towards account lockout
// To enable password failures to trigger account lockout, set lockoutOnFailure: true
                    var result =
                        await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,
                            lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User logged in.");
                        return RedirectToLocal(returnUrl);
                    }

                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning("User account locked out.");
                        return RedirectToAction(nameof(Lockout));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View(model);
                    }
                }
                else
                {
                    return View(model);
                }
            }

// If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ShredUser {UserName = model.Email, Email = model.Email};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    string callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");
                    return RedirectToLocal(returnUrl);
                }

                AddErrors(result);
            }

// If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            _logger.LogInformation("User logged out.");
            return Redirect("/");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
// Don't reveal that the user does not exist or is not confirmed
                    return RedirectToAction(nameof(ForgotPasswordConfirmation));
                }

// For more information on how to enable account confirmation and password reset please
// visit https://go.microsoft.com/fwlink/?LinkID=532713
                string code = await _userManager.GeneratePasswordResetTokenAsync(user);
                string callbackUrl = Url.ResetPasswordCallbackLink(user.Id, code, Request.Scheme);
                await _emailSender.SendEmailAsync(model.Email, "Reset Password",
                    $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }

// If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            if (code == null)
            {
                throw new ApplicationException("A code must be supplied for password reset.");
            }

            var model = new ResetPasswordViewModel {Code = code};
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
// Don't reveal that the user does not exist
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }

            AddErrors(result);
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion
    }
}