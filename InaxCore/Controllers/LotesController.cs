using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using InaxCore.Helpers.SqlConections;
using InaxCore.Models;
using InaxCore.Models.StaticInfo;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace InaxCore.Controllers
{
    public class LotesController : Controller
    {
        
        [HttpGet]
        public async Task<JsonResult> GetItems(string Code) {
            var dataDay = DateTime.Today;   
            //string query = "ProductCategoryAssignments?%24filter=ProductCategoryName%20eq%20%20'TINTAS'";
            //string tintascategory = await OdataConection.QueryJson(query);
            //var deserializedObject = JsonConvert.DeserializeObject<loteTableJsonObject>(tintascategory);

            //List<loteTable> catalogoTinta = new List<loteTable>();
            List<loteInvetid> restlista = new List<loteInvetid>();
            //if (deserializedObject.value.Count > 0)
            //{
                  //string IdInvent = deserializedObject.value[0].inventBatchId;
            string query2 = "AYT_InventBatches?%24filter=inventBatchId%20eq%20'" + Code +"'";
            string loteCadu = await OdataConection.QueryJson(query2);
                var deserializedObject2 = JsonConvert.DeserializeObject<loteItemJsonObject>(loteCadu);
                //List<loteModel> orderLinesList = new List<loteModel>();        
                foreach (loteModel item in deserializedObject2.value) {
                var numitem = item.itemId;
                var listalote = deserializedObject2.value.Where(x => x.itemId == numitem).ToList();
                if (listalote.Count > 0) {
                        //DateTime date1 = Convert.ToDateTime("12/12/2020 23:20:00");
                        DateTime date1 = Convert.ToDateTime(listalote[0].expDate);
                        Boolean vigente = IsValid(date1);
                        TimeSpan ts = date1 - DateTime.Now;
                        if (vigente)
                        {
                            int mesXvencer = NoMeses(ts);
                            listalote[0].Estado = "<span class=\"badge badge-success\">LOTE VIGENTE VENCE EN: " + mesXvencer + " MES(ES)</span>";
                            if (ts.Days <= 8){
                                listalote[0].Estado = "<span class=\"badge badge-warning\">LOTE VIGENTE VENCE EN 1 SEMANA</span>";
                            }
                            if (ts.Days <= 15)
                            {
                                listalote[0].Estado = "<span class=\"badge badge-warning\">LOTE VIGENTE VENCE EN 2 SEMANAS</span>";
                            }
                            if (ts.Days <= 31)
                            {
                                listalote[0].Estado  = "<span class=\"badge badge-warning\">LOTE VIGENTE VENCE EN 1 MES</span>";
                            }
                            if ((ts.Days > 15) && (ts.Days <= 29))
                            {
                                listalote[0].Estado = "<span class=\"badge badge-warning\">LOTE VIGENTE VENCE EN 3 SEMANAS</span>";
                            }
                        }
                        else
                        {
                            listalote[0].Estado = "<span class=\"badge badge-danger\">¡NO SURTIR! LOTE VENCIDO</span>";
                        }
                        var lotetemp = new loteInvetid();
                        lotetemp.itemId = listalote[0].itemId;
                        lotetemp.expDate = listalote[0].expDate;
                        lotetemp.Estado = listalote[0].Estado;
                        restlista.Add(lotetemp);
                    }
                //}
            }

            Console.WriteLine(restlista);
            return Json(new { data = restlista });
        }



        public Boolean IsValid(DateTime expDate)
        {
            DateTime now = DateTime.Now;
            Boolean vigente = false;
            if ( expDate >= now)
            {
                vigente = true;
            }
            return vigente;
        }

        public int NoMeses(TimeSpan ts)
        {
            float meses = ts.Days / 30;
            return Convert.ToInt32(meses);
        }

        public IActionResult viewLote()
        {
            return View();
        }

        public class loteItemJsonObject
        {
            public List<loteModel> value { get; set; }
        }

        public class loteItemInveJsonObject
        {
            public List<loteInvetid> value { get; set; }
        }


        public class loteTableJsonObject { 
          public List<loteTable> value { get; set; }
        }

        public class descripJsonObject { 
           public List<loteDescrip> value { get; set; }
        }
    }
}
