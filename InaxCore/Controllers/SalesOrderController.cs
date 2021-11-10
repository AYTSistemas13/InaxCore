using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InaxCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InaxCore.Controllers
{
    public class SalesOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetMySales(int workerId, string userName)
        {
            string query = "SalesOrderHeadersV2?" +
                "%24select=SalesOrderNumber,OrderTakerPersonnelNumber,SalesOrderName,ReleaseStatus,SalesOrderStatus,DeliveryModeCode,DefaultShippingWarehouseId,DefaultShippingSiteId,InvoiceCustomerAccountNumber,DefaultShippingWarehouseId" +
                "&%24filter=OrderTakerPersonnelNumber%20eq%20'"+workerId+"'&%24" +
                "orderby=OrderCreationDateTime%20desc&%24top=20";
            string ordersList = await OdataConection.QueryJson(query);
            var deserializedObject = JsonConvert.DeserializeObject<SalesJsonObject>(ordersList);
            Console.WriteLine(deserializedObject);
            List<InfoSalesOrder> ovList = new List<InfoSalesOrder>();
            foreach (InfoSalesOrder saleOrder in deserializedObject.value)
            {
                saleOrder.SalesMan = userName;
                Console.WriteLine(saleOrder);
                ovList.Add(saleOrder);
            }
            return Json(new { data = ovList });
        }
        public async Task<IActionResult> GetByFilter(string value, string filter)
        {
            string query = "";
            switch (filter)
            {
                case "ov":
                    query = "SalesOrderHeadersV2?%24" +
                        "select=SalesOrderNumber,OrderTakerPersonnelNumber,SalesOrderName,ReleaseStatus,SalesOrderStatus,DeliveryModeCode,DefaultShippingWarehouseId,DefaultShippingSiteId,InvoiceCustomerAccountNumber,DefaultShippingWarehouseId" +
                        "&%24filter=SalesOrderNumber%20eq%20'"+value+"'";
                    break;
                case "code":
                    query = "SalesOrderHeadersV2?%24" +
                        "select=SalesOrderNumber,OrderTakerPersonnelNumber,SalesOrderName,ReleaseStatus,SalesOrderStatus,DeliveryModeCode,DefaultShippingWarehouseId,DefaultShippingSiteId,InvoiceCustomerAccountNumber,DefaultShippingWarehouseId" +
                        "&%24filter=InvoiceCustomerAccountNumber%20eq%20'"+value+"'" +
                        "&%24orderby=OrderCreationDateTime%20desc&%24top=50";
                    break;
                case "name":
                    query = "SalesOrderHeadersV2?%24" +
                        "select=SalesOrderNumber,OrderTakerPersonnelNumber,SalesOrderName,ReleaseStatus,SalesOrderStatus,DeliveryModeCode,DefaultShippingWarehouseId,DefaultShippingSiteId,InvoiceCustomerAccountNumber,DefaultShippingWarehouseId" +
                        "&%24filter=SalesOrderName%20eq%20'" + value+"'" +
                        "&%24orderby=OrderCreationDateTime%20desc&%24top=50";
                    break;
            }
            string ordersList = await OdataConection.QueryJson(query);
            var deserializedObject = JsonConvert.DeserializeObject<SalesJsonObject>(ordersList);
            Console.WriteLine(deserializedObject);
            //List<InfoSalesOrder> ovList = new List<InfoSalesOrder>();
            foreach (InfoSalesOrder saleOrder in deserializedObject.value)
            {
                query = "Employees?%24select=Name&%24filter=PersonnelNumber%20eq%20'" + saleOrder.OrderTakerPersonnelNumber + "'";
                Dictionary<string, dynamic> workerId = await OdataConection.Query(query);
                if (workerId["value"].Count > 0)
                    saleOrder.SalesMan = workerId["value"][0].Name;
                else
                    saleOrder.SalesMan = "";
                //Console.WriteLine(saleOrder);
                //ovList.Add(saleOrder);
            }
            return Json(new { data = deserializedObject.value });
        }

        public async Task<IActionResult> GetOvInfo(string ov)
        {
            string query = "AYT_SalesLines?%24" +
                "select=ItemId,Name,SalesQty,SalesUnit&%24" +
                "filter=SalesId%20eq%20'"+ov+"'";
            string orderLines = await OdataConection.QueryJson(query);
            var deserializedObject = JsonConvert.DeserializeObject<SalesLinesJsonObject>(orderLines);
            return Json(deserializedObject.value);
        }



    }

    public class SalesJsonObject {
        public Dictionary<string,string> @odatacontext { get; set; }
        public List<InfoSalesOrder> value { get; set; }
    }
    public class SalesLinesJsonObject
    {
        public Dictionary<string, string> @odatacontext { get; set; }
        public List<SalesOrderLines> value { get; set; }
    }
}