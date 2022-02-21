using Entities.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;



namespace WebAPIWithCoreMvc.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]       
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {

            var stringContent = new StringContent(JsonConvert.SerializeObject(userForLoginDto), Encoding.UTF8, "application/json");

            var response = await GlobalVariables.webApiClient.PostAsync("Auth", stringContent);

            if(response.IsSuccessStatusCode)
            { 
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,userForLoginDto.Email)
            };
            var userIdentity = new ClaimsIdentity(claims, "a");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);
           
            return RedirectToAction("Index", "Categories");
            }

            return View();
        }
        
        public async Task<IActionResult> OnGetSignOut()
        {

            // kills the login cookie 
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            // redirect to web home or login page 
            return RedirectToAction("Login");

        }
    }
}
