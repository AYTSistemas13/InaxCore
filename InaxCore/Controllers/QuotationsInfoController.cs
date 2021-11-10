using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InaxCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InaxCore.Controllers
{
    public class QuotationsInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetMyQuotations(int workerId)
        {
            string query = "SalesQuotationHeaders?%24" +
                "select=SalesQuotationNumber,DefaultShippingSiteId,InvoiceCustomerAccountNumber,SalesQuotationStatus,ReceiptDateRequested,DeliveryModeCode,DefaultShippingWarehouseId,QuotationTakerPersonnelNumber,SalesQuotationName&%24" +
                "filter=QuotationTakerPersonnelNumber%20eq%20'"+workerId+ "'&%24" +
                "orderby=SalesQuotationNumber%20desc&%24" +
                "top=20";
            string quotationsList = await OdataConection.QueryJson(query);
            var deserializedObject = JsonConvert.DeserializeObject<QuotationsJsonObject>(quotationsList);
            Console.WriteLine(deserializedObject);
            List<InfoQuotationOrder> quoList = new List<InfoQuotationOrder>();
            foreach (InfoQuotationOrder quotation in deserializedObject.value)
            {
                quoList.Add(quotation);
            }
            return Json(new { data = quoList });
        }
        public async Task<IActionResult> GetByFilter(string value, string filter)
        {
            string query = "";
            switch (filter)
            {
                case "cot":
                    query = "SalesQuotationHeaders?%24" +
                        "select=SalesQuotationNumber,DefaultShippingSiteId,InvoiceCustomerAccountNumber,SalesQuotationStatus,ReceiptDateRequested,DeliveryModeCode,DefaultShippingWarehouseId,QuotationTakerPersonnelNumber,SalesQuotationName" +
                        "&%24filter=SalesQuotationNumber%20eq%20'"+value+"'";
                    break;
                case "code":
                    query = "SalesQuotationHeaders?%24" +
                        "select=SalesQuotationNumber,DefaultShippingSiteId,InvoiceCustomerAccountNumber,SalesQuotationStatus,ReceiptDateRequested,DeliveryModeCode,DefaultShippingWarehouseId,QuotationTakerPersonnelNumber,SalesQuotationName&%24" +
                        "filter=InvoiceCustomerAccountNumber%20eq%20'"+value+"'&%24" +
                        "orderby=SalesQuotationNumber%20desc&%24top=50";
                    break;
                case "name":
                    query = "SalesQuotationHeaders?%24" +
                        "select=SalesQuotationNumber,DefaultShippingSiteId,InvoiceCustomerAccountNumber,SalesQuotationStatus,ReceiptDateRequested,DeliveryModeCode,DefaultShippingWarehouseId,QuotationTakerPersonnelNumber,SalesQuotationName&%24" +
                        "filter=SalesQuotationName%20eq%20'"+value+"'&%24" +
                        "orderby=SalesQuotationNumber%20desc&%24top=50";
                    break;
            }
            string quotationsList = await OdataConection.QueryJson(query);
            var deserializedObject = JsonConvert.DeserializeObject<QuotationsJsonObject>(quotationsList);
            Console.WriteLine(deserializedObject);
            List<InfoQuotationOrder> quoList = new List<InfoQuotationOrder>();
            foreach (InfoQuotationOrder quotation in deserializedObject.value)
            {
                quoList.Add(quotation);
            }
            return Json(new { data = quoList });
        }

        public async Task<IActionResult> GetCotInfo(string cot)
        {
            string query = "AYT_SalesLines?%24" +
                "select=ItemId,Name,SalesQty,SalesUnit&%24" +
                "filter=SalesId%20eq%20'" + cot + "'";
            string orderLines = await OdataConection.QueryJson(query);
            var deserializedObject = JsonConvert.DeserializeObject<SalesLinesJsonObject>(orderLines);
            List<SalesOrderLines> orderLinesList = new List<SalesOrderLines>();
            foreach (SalesOrderLines orderLine in deserializedObject.value)
            {
                orderLinesList.Add(orderLine);
            }
            Console.WriteLine(orderLinesList);
            return Json(orderLinesList);
        }

    }
    public class QuotationsJsonObject
    {
        public Dictionary<string, string> @odatacontext { get; set; }
        public List<InfoQuotationOrder> value { get; set; }
    }
    public class LinesQuotationsJsonObject
    {
        public Dictionary<string, string> @odatacontext { get; set; }
        public List<SalesOrderLines> value { get; set; }
    }
}