using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InaxCore.Models;
using System.Data.SqlClient;
using InaxCore.Helpers.SqlConections;

namespace InaxCore.Controllers
{
    [Authorize]
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

        public async Task<IActionResult> GetUserInfo() {
            string query = "SystemUsers?%24select=UserID,UserName,Company&%24filter=Email%20eq%20'"+User.Identity.Name+"'";
            Dictionary<string, dynamic> personelInfo = await OdataConection.Query(query);
            UserIdentities currentUser = new UserIdentities
            {
                Company = personelInfo["value"][0].Company,
                UserName = personelInfo["value"][0].UserName
            };
            query = "Employees?%24select=PersonnelNumber&%24filter=Education%20eq%20'"+ personelInfo["value"][0].UserID + "'";
            Dictionary<string, dynamic> workerId = await OdataConection.Query(query);
            currentUser.WorkerId = workerId["value"][0].PersonnelNumber;
            foreach (var userOffice in User.Claims.ToArray()){ 
                if (userOffice.Type == "officename")
                    currentUser.BranchOffice = userOffice.Value;
            }
            return Json(currentUser);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
