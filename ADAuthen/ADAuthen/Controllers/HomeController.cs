using ADAuthen.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Office.Interop.Outlook;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
//using Outlook = Microsoft.Office.Interop.Outlook;

namespace ADAuthen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("/addroleadmin")]
        public async Task<IActionResult> AddRoleAdminAsync()
        { 
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            //var claimsIdentity = new ClaimsIdentity(claims, NegotiateDefaults.AuthenticationScheme);
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrinciple);
            return View();
        }


        [HttpGet("/findroles")]
        public IActionResult FindRoles()
        {
            var roleNames = ((ClaimsIdentity)User.Identity).FindAll(ClaimTypes.Role).ToList();
            List<string> roles = new List<string>();
            foreach(var role in roleNames)
            {
                roles.Add(role.Type + " : " + role.Value);
            }
            TempData["roles"] = roles;



            return View();
        }

        [HttpGet("/outlook")]
        public IActionResult Outlook()
        {
            List<string> OutlookInfo = new List<string>();
            var appOutlook = new Microsoft.Office.Interop.Outlook.Application();
            AddressEntry addrEntry = appOutlook.Session.CurrentUser.AddressEntry;
            if (addrEntry.Type == "EX")
            {
                ExchangeUser currentUser = appOutlook.Session.CurrentUser.
                    AddressEntry.GetExchangeUser();
                if (currentUser != null)
                {
                    OutlookInfo.Add("Name : " + currentUser.Name);
                    OutlookInfo.Add("OfficeLocation : " + currentUser.OfficeLocation);
                    OutlookInfo.Add("YomiDepartment : " + currentUser.YomiDepartment);
                    OutlookInfo.Add("Department : " + currentUser.Department);
                    TempData["outlookInfo"] = OutlookInfo;
                }
            }
            return View();
        }


        [HttpGet("/secured")]
        [Authorize(Roles = "Admin")]
        public IActionResult Secured()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
