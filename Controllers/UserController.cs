//Author: Shaan Davis
//Date: October 22, 2019
//Assignment: Homework 4
//Description: Toy Store with Identity

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


//TODO: Change this using statement to match your project
using fa19projectgroup16.DAL;
using fa19projectgroup16.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Net.Mail;

//TODO: Change this namespace to match your project
namespace fa19projectgroup16.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        private PasswordValidator<AppUser> _passwordValidator;
        private AppDbContext _db;

        public UserController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signIn)
        {
            _db = context;
            _userManager = userManager;
            _signInManager = signIn;
            //user manager only has one password validator
            _passwordValidator = (PasswordValidator<AppUser>)userManager.PasswordValidators.FirstOrDefault();
        }

        // GET: /User/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            RegisterViewModel rvm = new RegisterViewModel();
            return View(rvm);
        }

        // POST: /User/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    //TODO: Add the rest of the custom user fields here
                    UserName = rvm.Email,
                    Email = rvm.Email,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    MiddleInitial = rvm.MiddleInit,
                    Street = rvm.Street,
                    City = rvm.City,
                    State = rvm.State,
                    Zip = rvm.Zip,
                    Birthday = rvm.Birthday,
                    PhoneNumber = rvm.PhoneNumber,
                    Is_enabled = true

                };

                IdentityResult result = await _userManager.CreateAsync(user, rvm.Password);
                if (result.Succeeded)
                {
                    //TODO: Add user to desired role. This example adds the user to the customer role
                    await _userManager.AddToRoleAsync(user, "Customer");


                    Microsoft.AspNetCore.Identity.SignInResult result2 = await _signInManager.PasswordSignInAsync(rvm.Email, rvm.Password, false, lockoutOnFailure: false);
                    return RedirectToAction("Selector", "Accounts");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(rvm);
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated) //user has been redirected here from a page they're not authorized to see
            {
                return View("Error", new string[] { "Access Denied" });
            }
            _signInManager.SignOutAsync(); //this removes any old cookies hanging around
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            List<string> userids = _db.UserRoles.Where(a => a.RoleId == "d244674c-2d18-4741-9b2c-90d77b83bbf7").Select(b => b.UserId).Distinct().ToList();
            List<AppUser> employees = _db.Users.Where(a => userids.Any(c => c == a.Id)).ToList();
            AppUser employee = _db.Users.FirstOrDefault(u => u.Email == model.Email);

            foreach (AppUser u in employees)
            {
                if (employee == u && employee.Is_Employed == false)
                {
                    ModelState.AddModelError("", "Invalid login attempt. You are no longer employed.");
                    return View(model);
                }
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Accounts");   
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }

        //GET: Account/Index
        public ActionResult Index()
        {
            IndexViewModel ivm = new IndexViewModel();

            //get user info
            String id = User.Identity.Name;
            AppUser user = _db.Users.FirstOrDefault(u => u.UserName == id);

            //populate the view model
            ivm.Email = user.Email;
            ivm.HasPassword = true;
            ivm.UserID = user.Id;
            ivm.UserName = user.UserName;

            //send data to the view
            return View(ivm);
        }

        //GET: User/Modify
        public IActionResult Modify()
        {
            AppUser user = _db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);

            ManageProfileViewModel model = new ManageProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                City = user.City,
                MiddleInitial = user.MiddleInitial,
                Street = user.Street,
                State = user.State,
                Zip = user.Zip,
                PhoneNumber = user.PhoneNumber,
                SSN = user.SSN,
                Email = user.Email

            };

            foreach (AppUser u in GetAllCustomers())
            {
                if (user == u)
                {
                    ViewBag.UserRole = "Customer";
                }
            }

            return View(model);
        }

        // POST: /Users/ManageProfile
        [HttpPost]
        public IActionResult Modify(ManageProfileViewModel mpvm)
        {
            if (ModelState.IsValid)
            {
                AppUser user = _db.Users.FirstOrDefault(u => u.Email == mpvm.Email);

                user.FirstName = mpvm.FirstName;
                user.LastName = mpvm.LastName;
                user.City = mpvm.City;
                user.MiddleInitial = mpvm.MiddleInitial;
                user.Street = mpvm.Street;
                user.State = mpvm.State;
                user.Zip = mpvm.Zip;
                user.PhoneNumber = mpvm.PhoneNumber;
                foreach (AppUser u in GetAllCustomers())
                {
                    if (user == u)
                    {
                        user.SSN = mpvm.SSN;
                    }
                }

                _db.Update(user);
                _db.SaveChanges();
                foreach (AppUser u in GetAllCustomers())
                {
                    if (user == u)
                    {
                        return RedirectToAction("ManageCustomers");
                    }
                }
                return RedirectToAction("ManageEmployees");

            }


            return View(mpvm);
        }

        public ActionResult ViewProfile()
        {
            AppUser user = _db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);

            ManageProfileViewModel model = new ManageProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                City = user.City,
                MiddleInitial = user.MiddleInitial,
                Street = user.Street,
                State = user.State,
                Zip = user.Zip,
                PhoneNumber = user.PhoneNumber,
                SSN = user.SSN,
                Email = user.Email

            };

            foreach (AppUser u in GetAllCustomers())
            {
                if (user == u)
                {
                    ViewBag.UserRole = "Customer";
                }
            }

            return View(model);
        }

        //Logic for change password
        // GET: /Account/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = await _userManager.ChangePasswordAsync(userLoggedIn, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(userLoggedIn, isPersistent: false);

                MailAddress to = new MailAddress(userLoggedIn.Email);
                MailAddress from = new MailAddress("bevobankandtrustgroup16@gmail.com");
                MailMessage mail = new MailMessage(from, to);
                mail.Subject = "Team 16: Change Password Message";
                mail.Body = "You have changed your password. I hope this one is better.";

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("bevobankandtrustgroup16@gmail.com", "Abc123!!");
                smtp.EnableSsl = true;
                smtp.Send(mail);

                return RedirectToAction("Index", "Home");
            }
            AddErrors(result);



            return View(model);
        }

        //GET:/Account/AccessDenied
        public ActionResult AccessDenied(String ReturnURL)
        {
            return View("Error", new string[] { "Access is denied" });
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        public List<AppUser> GetAllCustomers()
        {
            List<string> userids = _db.UserRoles.Where(a => a.RoleId == "d26befd1-36fc-49a0-85d3-12d201178715").Select(b => b.UserId).Distinct().ToList();
            //The first step: get all user id collection as userids based on role from db.UserRoles

            List<AppUser> customers = _db.Users.Where(a => userids.Any(c => c == a.Id)).ToList();

            return customers;
        }
    }
}
