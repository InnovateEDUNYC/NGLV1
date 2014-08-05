using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Humanizer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Infrastructure.Security;
using NGL.Web.Models;
using NGL.Web.Models.Account;

namespace NGL.Web.Controllers
{
    public partial class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IResourceService _resourceService;
        private readonly IGenericRepository _genericRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IMapper<Staff, UserModel> _staffToUserModelMapper;
        private readonly IMapper<AddUserModel, Staff> _addUserModelToStaffMapper;
        private readonly IMapper<AddUserModel, ApplicationUser> _addUserModelToApplicationUserMapper;

        public AccountController(
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            IResourceService resourceService,
            IGenericRepository genericRepository, 
            IStaffRepository staffRepository,
            IMapper<Staff, UserModel> staffToUserModelMapper,
            IMapper<AddUserModel, Staff> addUserModelToStaffMapper,
            IMapper<AddUserModel, ApplicationUser> addUserModelToApplicationUserMapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _resourceService = resourceService;
            _genericRepository = genericRepository;
            _staffRepository = staffRepository;
            _staffToUserModelMapper = staffToUserModelMapper;
            _addUserModelToStaffMapper = addUserModelToStaffMapper;
            _addUserModelToApplicationUserMapper = addUserModelToApplicationUserMapper;
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
                CreateAuthenticationTicket(user);
                return RedirectToLocal(returnUrl);
            }
                
            ModelState.AddModelError("", "Invalid username or password.");

            return View(model);
        }

        [AuthorizeFor(Resource = "user", Operation = "view")]
        public virtual ActionResult Users()
        {
            var users = _staffRepository.GetStaffWithUsers();
            var userModels = users.Select(_staffToUserModelMapper.Build).ToList();
            return View(userModels);
        }

        // GET: /Account/AddUser
        [AuthorizeFor(Resource = "user", Operation = "create")]
        public virtual ActionResult AddUser()
        {
            return View();
        }

        //
        // POST: /Account/AddUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFor(Resource = "user", Operation = "create")]
        public virtual ActionResult AddUser(AddUserModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var staff = _addUserModelToStaffMapper.Build(model);
            _genericRepository.Add(staff);
            _genericRepository.Save();

            var user = _addUserModelToApplicationUserMapper.Build(model);
            var result = _userManager.Create(user, model.Password);
            if (result.Succeeded)
            {
                _userManager.AddToRole(user.Id, model.Role.Humanize());
                return RedirectToAction("Users");
            }

            AddErrors(result);

            return View(model);
        }

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
                    var userId = _userManager.FindByName(User.Identity.Name).Id;
                    IdentityResult result = await _userManager.ChangePasswordAsync(userId, model.CurrentPassword, model.NewPassword);
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
                    var userId = _userManager.FindByName(User.Identity.Name).Id;
                    IdentityResult result = await _userManager.AddPasswordAsync(userId, model.NewPassword);
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

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddDays(-1);    

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

        public void CreateAuthenticationTicket(ApplicationUser user)
        {
            var roleId = user.Roles.First().RoleId;
            var role = _roleManager.FindById(roleId).Name.DehumanizeTo<ApplicationRole>();

            var serializeModel = new NglPrincipalSerializedModel {Resources = _resourceService.GetResourcesFor(role)};

            var serializer = new JavaScriptSerializer();
            var userData = serializer.Serialize(serializeModel);

            var authTicket = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now, DateTime.Now.AddHours(8), false, userData);
            var encTicket = FormsAuthentication.Encrypt(authTicket);
            var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            Response.Cookies.Add(faCookie);
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
            var user = _userManager.FindByName(User.Identity.Name);
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