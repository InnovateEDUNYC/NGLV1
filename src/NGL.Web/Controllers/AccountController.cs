using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Humanizer;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;
using NGL.Web.Models.Account;

namespace NGL.Web.Controllers
{
    public partial class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IGenericRepository _genericRepository;

        public AccountController(UserManager<ApplicationUser> userManager, IGenericRepository genericRepository)
        {
            _userManager = userManager;
            _genericRepository = genericRepository;
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public virtual ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid) 
                return View(model);

            var user = await _userManager.FindAsync(model.Username, model.Password);
            if (user != null)
            {
                await SignInAsync(user, model.RememberMe);
                return RedirectToLocal(returnUrl);
            }
                
            ModelState.AddModelError("", "Invalid username or password.");

            return View(model);
        }

        public virtual ActionResult Users()
        {
            var users = _genericRepository.Query(new UserRolesQuery(), u => u.AspNetRoles).ToList();
            var um = users.Select(u => new UserModel
            {
                Username = u.UserName, 
                Roles = string.Join(", ", u.AspNetRoles.Select(r => r.Name))
            }).ToList();

            return View(um);
        }

        //
        // GET: /Account/AddUser
        public virtual ActionResult AddUser()
        {
            return View();
        }

        //
        // POST: /Account/AddUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult AddUser(AddUserModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicationUser {UserName = model.Username};
            var result = _userManager.Create(user, model.Password);
            if (result.Succeeded)
            {
                _userManager.AddToRole(user.Id, model.Role.Humanize());
                return RedirectToAction("Users");
            }

            AddErrors(result);

            return View(model);
        }

        //
        // POST: /Account/Disassociate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Disassociate(string loginProvider, string providerKey)
        {
            IdentityResult result = await _userManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            ManageMessageId? message = result.Succeeded ? ManageMessageId.RemoveLoginSuccess : ManageMessageId.Error;
            return RedirectToAction(Actions.ChangePassword(message));
        }

        //
        // GET: /Account/ChangePassword
        public virtual ActionResult ChangePassword(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            ViewBag.HasLocalPassword = HasPassword();
            ViewBag.ReturnUrl = Url.Action("ChangePassword");
            return View();
        }

        //
        // POST: /Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> ChangePassword(ChangePasswordModel model)
        {
            bool hasPassword = HasPassword();
            ViewBag.HasLocalPassword = hasPassword;
            ViewBag.ReturnUrl = Url.Action("ChangePassword");
            if (hasPassword)
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await _userManager.ChangePasswordAsync(User.Identity.GetUserId(), model.CurrentPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ChangePassword", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    
                    AddErrors(result);
                }
            }
            else
            {
                // User does not have a password so remove any validation errors caused by a missing CurrentPassword field
                ModelState state = ModelState["CurrentPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    IdentityResult result = await _userManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ChangePassword", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }


        [ChildActionOnly]
        public virtual ActionResult RemoveAccountList()
        {
            var linkedAccounts = _userManager.GetLogins(User.Identity.GetUserId());
            ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
            return PartialView("_RemoveAccountPartial", linkedAccounts);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, identity);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = _userManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}