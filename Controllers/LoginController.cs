using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Csharp_Seat_Booking_System.Models;
using Csharp_Seat_Booking_System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;
using Microsoft.AspNetCore.Http;
using Database.Connect;
using Website.Models;

namespace Csharp_Seat_Booking_System.Controllers
{
    public class LoginController : Controller
    {
        public static bool sessionState { get; private set;}
        private ConnDatabase connect;
        private const bool IsPersistent = false;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;


        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            sessionState = false;
            return RedirectToAction("ViewEvents", "Events");

        }

        public IActionResult Login()
        {

            return View();
        }

        [HttpGet]
        public IActionResult CompanyLogin()
        {

            return View();

        }

        [HttpGet]
        public IActionResult UserLogin()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserLogin(UserLoginModel model)
        {
            //we will use a function to communicate with the database for validating the user
            if (ModelState.IsValid)
            {
                connect = new ConnDatabase();
                connect.sqlQuery("SELECT * FROM Users");
                
                foreach (DataRow item in connect.Execute().Rows)
                {
                    Console.WriteLine(item[1]);
                    if(item[1].ToString() == model.UserEmail && UserLoginModel.PasswordMatch(item[2].ToString(), model.UserPassword)){
                        HttpContext.Session.SetString("Email", model.UserEmail);
                        sessionState = true;
                        return Redirect("../Home/Index");
                    }
                }
                /* var result = await signInManager.PasswordSignInAsync(model.UserEmail, model.UserPassword, IsPersistent, false);

                if (result.Succeeded)
                {

                    return RedirectToAction("ViewEvents", "Events");

                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
 */

            }

            //redirecting the view to index for testing purposes
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompanyLogin(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.UserEmail, model.UserPassword, IsPersistent, false);

                if (result.Succeeded)
                {

                    return RedirectToAction("ViewEvents", "Events");

                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");


            }

            return View(model);

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserRegister(UserRegisterModel model)
        {
            
            //We are going to communicate with the database here to input user data
            //we will create the data base in the models
            //we can rather make a function that will communicate with the database
            if (ModelState.IsValid)
            {
                var name =  model.UserEmail;
                var pass = model.UserPassword;
                
                string hashed_password = SecurePasswordHasherHelper.Hash(pass);
    
                Console.WriteLine(hashed_password);
                connect = new ConnDatabase();
                connect.sqlQuery("INSERT INTO Users (UserEmail, UserPassword) Values('"+ name +"', '"+ hashed_password+ "')");
                connect.NonExecute();
               /* var user = new IdentityUser { UserName = model.UserEmail };
                var createdUser = await userManager.CreateAsync(user, model.UserPassword);
                Console.WriteLine(createdUser);
                if (createdUser.Succeeded)
                {

                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("ViewEvents", "Events");

                }

                foreach (var error in createdUser.Errors)
                {

                    ModelState.AddModelError(string.Empty, error.Description);

                } */
            }
                    // return RedirectToAction("ViewEvents", "Events");
            return View(model);


        }

        [HttpGet]
        public IActionResult CompanyRegister()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompanyRegister(CompanyRegisterModel model)
        {

            if (ModelState.IsValid)
            {

                var name =  model.CompanyEmail;
                var pass = model.CompanyPassword;
                var confirmPass = model.CompanyConfirmPassword;
                
                string hashed_password = SecurePasswordHasherHelper.Hash(pass);
    
                connect = new ConnDatabase();
                connect.sqlQuery("INSERT INTO Company (CompanyEmail, CompanyPassword) Values('"+ name +"', '"+ hashed_password+ "')");
                connect.NonExecute();
            }

            return View(model);

        }
        
    }
}