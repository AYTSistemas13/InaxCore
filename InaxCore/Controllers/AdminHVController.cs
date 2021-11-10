using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InaxCore.Models;
using InaxCore.Helpers.SqlConections;
using System.Data.SqlClient;

namespace InaxCore.Controllers
{
  public class AdminHVController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public async Task<JsonResult> GetHerramientas()
    {
      AdminHVInfo herramientas = new AdminHVInfo();
      List<String[]> result = await herramientas.GetHerramientas();
      return Json(new { data = result });
    }

    [HttpPost]
    public async Task<IActionResult> Editar(int Id, string SKU, string Descripcion, string Enlace)
    {
      AdminHVInfo herramientas = new AdminHVInfo();
      int result = await herramientas.Editar(Id, SKU, Descripcion, Enlace);
      if (result > 0)
      {
        return Json(new { msg = "Exito", status = result });
      }
      else
      {
        return Json(new { msg = "Fallo al acuatlizar", status = result });
      }
    }

    [HttpPost]
    public async Task<IActionResult> Deshabilitar(int Status, string SKU)
    {
      AdminHVInfo herramientas = new AdminHVInfo();
      int result = await herramientas.Deshabilitar(Status, SKU);
      if (result > 0)
      {
        return Json(new { msg = "Exito", status = result });
      }
      else
      {
        return Json(new { msg = "Fallo al acuatlizar", status = result });
      }
    }

    [HttpPost]
    public async Task<IActionResult> Agregar(string SKU, string Descripcion, string Enlace)
    {
      AdminHVInfo herramientas = new AdminHVInfo();
      int result = await herramientas.Agregar(SKU, Descripcion, Enlace);
      if (result > 0)
      {
        return Json(new { msg = "Exito", status = result });
      }
      else
      {
        return Json(new { msg = "Fallo al acuatlizar", status = result });
      }
    }
  }
}