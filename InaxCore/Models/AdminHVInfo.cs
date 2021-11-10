using InaxCore.Helpers.SqlConections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InaxCore.Models
{
  public class AdminHVInfo
  {

    public async Task<List<String[]>> GetHerramientas()
    {
      SqlDataReader herramientas = await ProdConection.GetReader("SELECT * FROM HerramientaVentas");
      List<string[]> adminHVList = new List<string[]>();
      if (herramientas.HasRows)
      {
        int contador = 0;
        while (herramientas.Read())
        {
          String[] arr;
          arr = new String[] {
            herramientas[1].ToString(),
            herramientas[2].ToString(),
            "<a href="+herramientas[3].ToString()+" target=\"_blank\"><button class=\"table_button\" style=\"border-style:none; border-radius:1em; position: relative;left: 5em; padding: 0.3em 0.8em; background: #334f8c; color: #fff;\" onmouseover=\"this.style.background='#47577b'\" onmouseout=\"this.style.background='#334f8c'\">Ir a Herramienta</button></a>",
            "<div class=\"row\"><div class=\"custom-control custom-switch\"><input type=\"checkbox\" onclick=\"deshabilitar('"+herramientas[1].ToString()+"', this)\" class=\"custom-control-input enablerButton material-switch\" checked=\"\" data-sku=\""+herramientas[1].ToString()+"\" id=\"customSwitch-"+contador+"\"><label class=\"custom-control-label\" for=\"customSwitch-"+contador+"\"></label></div><span onclick=\"editar('" + herramientas[0].ToString()+"','"+herramientas[1].ToString()+"','"+herramientas[2].ToString()+"','"+herramientas[3].ToString()+"')\" style=\"cursor:pointer; \"><i class=\"far fa-edit\" aria-hidden=\"true\"></i></span></div>"
          };
            contador++;
          adminHVList.Add(arr);
        }
      }
      return adminHVList;
    }

    public async Task<int> Editar(int Id, string SKU, string Descripcion, string Enlace)
    {
      ProdConection conection = new ProdConection();
      int resultDel = await conection.queryInsert("UPDATE HerramientaVentas SET SKU = '" + SKU + "', Descripcion = '" + Descripcion + "', Enlace = '" + Enlace + "' WHERE SKU = '" + SKU + "';");
      return resultDel;
    }
    
    public async Task<int> Deshabilitar(int Status, string SKU)
    {
      ProdConection conection = new ProdConection();
      int resultDel = await conection.queryInsert("UPDATE HerramientaVentas SET Status = '" + Status + "' WHERE SKU = '" + SKU + "';");
      return resultDel;
    }


    public async Task<int> Agregar(string SKU, string Descripcion, string Enlace)
    {
      ProdConection conection = new ProdConection();
      int resultDel = await conection.queryInsert("INSERT INTO HerramientaVentas (SKU,Descripcion,Enlace,Status) VALUES ('" + SKU + "', '" + Descripcion + "', '" + Enlace + "',1);");
      return resultDel;
    }

    public int Id { get; set; }
    public string SKU { get; set; }
    public string Descripcion { get; set; }
    public string Enlace { get; set; }
  }
}
