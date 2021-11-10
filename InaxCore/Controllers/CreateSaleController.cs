using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using InaxCore.Helpers.SqlConections;
using InaxCore.Models;
using InaxCore.Models.StaticInfo;
using InaxCore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InaxCore.Controllers
{
    public class CreateSaleController : Controller
    {
        public async Task<IActionResult> Index()
        {
            CreateSaleHeaderViewModel saleHeaderViewModel = new CreateSaleHeaderViewModel { 
                SalesOriginList = await StaticSalesOrigin.GetSalesOriginList(),
                EmployeeInfoList = await StaticEmployeeList.GetEmployeeInfoList()
            };
            return View(saleHeaderViewModel);
        }
        public async Task<IActionResult> GetPrincipalInfo()
        {
            return Json(new { 
                exchangeRate = await StaticExhangeRate.GetRate(), 
                clientList = await StaticCustomerList.GetCustomerList() 
            });
        }
    }
}