using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using InaxCore.Helpers.SqlConections;
using InaxCore.Models;
using InaxCore.Models.StaticInfo;
using Microsoft.AspNetCore.Mvc;

namespace InaxCore.Controllers
{
    public class PromoCodesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            SqlDataReader promoCodesReader = await ProdConection.GetReader("SELECT * FROM AYT_PromoCodes");
            List<PromoCodeInfo> promoCodesList = new List<PromoCodeInfo>();
            while (promoCodesReader.Read())
            {
                PromoCodeInfo temporalCode = new PromoCodeInfo();
                temporalCode.Id = promoCodesReader.GetInt64(0);
                temporalCode.PromoCode = promoCodesReader.GetString(1);
                temporalCode.ItemsList = promoCodesReader.GetString(2);
                temporalCode.BlackList = promoCodesReader.GetString(3);
                temporalCode.Expires = promoCodesReader.GetBoolean(4);
                temporalCode.MaxRedeemed = promoCodesReader.GetInt32(5);
                temporalCode.Redeemed = promoCodesReader.GetInt32(6);
                temporalCode.ExpireDate = promoCodesReader.GetDateTime(7);
                temporalCode.InsertDate = promoCodesReader.GetDateTime(8);
                temporalCode.StartDate = promoCodesReader.GetDateTime(9);
                temporalCode.Enabled = promoCodesReader.GetBoolean(10);
                temporalCode.SiteId = promoCodesReader.GetString(11) == "All"? "TODOS": promoCodesReader.GetString(11);
                promoCodesList.Add(temporalCode);
            }
            ViewData["promoCodeList"] = promoCodesList;
            return View();
        }

        public async Task<IActionResult> CodeInfo(string codeId)
        {
            SqlDataReader redeemedCodesReader = await ProdConection.GetReader("SELECT * FROM AYT_PromoRedeemedLog WHERE PromoCode = '"+codeId+"'");
            List<RedeemedCodeInfo> redeemedCodesList = new List<RedeemedCodeInfo>();
            while (redeemedCodesReader.Read())
            {
                RedeemedCodeInfo temporalRedeemedCode = new RedeemedCodeInfo
                {
                  Id = redeemedCodesReader.GetInt64(0),
                  PromoCode = redeemedCodesReader.GetString(1),
                  Cot = redeemedCodesReader.GetString(2),
                  ClientCode = redeemedCodesReader.GetString(3),
                  InsertDate = redeemedCodesReader.GetDateTime(4),
                  ClientName = redeemedCodesReader.GetString(5)
                };
                redeemedCodesList.Add(temporalRedeemedCode);
            }    
            return View(redeemedCodesList);
        }
        public async Task<IActionResult> CreateCode()
        {
            //SqlDataReader articlesReader = await ProdConection.GetReader("SELECT ItemNumber, SearchName FROM articulos2");
            //List<ArticleInfo> articlesList = new List<ArticleInfo>();
            SqlDataReader itemFamilyReader = await ProdConection.GetReader("SELECT DISTINCT PRODUCTCATEGORYNAME AS FAMILIA FROM EcoResProductCategoryAssignmentStaging T1 WHERE T1.PRODUCTCATEGORYHIERARCHYNAME = 'FAMILIA'ORDER BY T1.PRODUCTCATEGORYNAME");
            List<ItemFamily> familyList = new List<ItemFamily>();
            //while (articlesReader.Read())
            //{
            //    ArticleInfo temporalArticle = new ArticleInfo
            //    {
            //        ItemNumber = articlesReader.GetString(0),
            //        SearchName = articlesReader.GetString(1)
            //    };
            //    articlesList.Add(temporalArticle);
            //}
            while (itemFamilyReader.Read())
            {
                ItemFamily temporalItemFamily = new ItemFamily {
                    FamilyName = itemFamilyReader.GetString(0)
                };
                familyList.Add(temporalItemFamily);
            }
            string query = "OperationalSites";
            Dictionary<string, dynamic> sites = await OdataConection.Query(query);
            List<StoreSite> sitesArray = new List<StoreSite>();
            sitesArray.Add(new StoreSite { siteId = "All", siteName = "TODOS" });
            foreach (var site in sites["value"])
            {
                sitesArray.Add(new StoreSite { siteId = site.SiteId, siteName = site.SiteName });
            }
            //ViewData["articlesList"] = articlesList;
            ViewData["familyList"] = familyList;
            //ViewData["customerList"] = await StaticCustomerList.GetCustomerList();
            return View(sitesArray);
        }

        public async Task<IActionResult> UpdateCode(int codeId)
        {
            PromoCodeInfo temporalRedeemedCode = new PromoCodeInfo();
            SqlDataReader redeemedCodesReader = await ProdConection.GetReader("SELECT * FROM AYT_PromoCodes WHERE Id = "+ codeId );
            SqlDataReader itemFamilyReader = await ProdConection.GetReader("SELECT DISTINCT PRODUCTCATEGORYNAME AS FAMILIA FROM EcoResProductCategoryAssignmentStaging T1 WHERE T1.PRODUCTCATEGORYHIERARCHYNAME = 'FAMILIA'ORDER BY T1.PRODUCTCATEGORYNAME");
            List<ItemFamily> familyList = new List<ItemFamily>();
            while (itemFamilyReader.Read())
            {
                ItemFamily temporalItemFamily = new ItemFamily
                {
                    FamilyName = itemFamilyReader.GetString(0)
                };
                familyList.Add(temporalItemFamily);
            }
            while (redeemedCodesReader.Read())
            {
                temporalRedeemedCode.Id = redeemedCodesReader.GetInt64(0);
                temporalRedeemedCode.PromoCode = redeemedCodesReader.GetString(1);
                temporalRedeemedCode.ItemsList = @redeemedCodesReader.GetString(2);
                temporalRedeemedCode.BlackList = redeemedCodesReader.GetString(3);
                temporalRedeemedCode.Expires = redeemedCodesReader.GetBoolean(4);
                temporalRedeemedCode.MaxRedeemed = redeemedCodesReader.GetInt32(5);
                temporalRedeemedCode.Redeemed = redeemedCodesReader.GetInt32(6);
                temporalRedeemedCode.ExpireDate = redeemedCodesReader.GetDateTime(7);
                temporalRedeemedCode.InsertDate = redeemedCodesReader.GetDateTime(8);
                temporalRedeemedCode.StartDate = redeemedCodesReader.GetDateTime(9);
                temporalRedeemedCode.Enabled = redeemedCodesReader.GetBoolean(10);
                temporalRedeemedCode.SiteId = redeemedCodesReader.GetString(11);
                temporalRedeemedCode.FamiliesSelected = redeemedCodesReader.GetString(12);
            }

            SqlDataReader articlesReader = await ProdConection.GetReader("SELECT ItemNumber, SearchName FROM articulos");
            List<ArticleInfo> articlesList = new List<ArticleInfo>();
            while (articlesReader.Read())
            {
                ArticleInfo temporalArticle = new ArticleInfo
                {
                    ItemNumber = articlesReader.GetString(0),
                    SearchName = articlesReader.GetString(1)
                };
                articlesList.Add(temporalArticle);
            }
            string query = "OperationalSites";
            Dictionary<string, dynamic> sites = await OdataConection.Query(query);
            List<StoreSite> sitesArray = new List<StoreSite>();
            sitesArray.Add(new StoreSite { siteId = "All", siteName = "TODOS" });
            foreach (var site in sites["value"])
            {
                sitesArray.Add(new StoreSite { siteId = site.SiteId, siteName = site.SiteName });
            }

            ViewData["sitesArray"] = sitesArray;
            ViewData["articlesList"] = articlesList;
            ViewData["familyList"] = familyList;
            return View(temporalRedeemedCode);
        }

        public async Task<IActionResult> GetCustomers()
        {
            List<ClientJsonReturn> clientList = new List<ClientJsonReturn>();
            foreach(CustomerInfo customer in await StaticCustomerList.GetCustomerList())
            {
                ClientJsonReturn temporalCustomer = new ClientJsonReturn {  id = customer.CustomerAccount, text = customer.OrganizationName };
                clientList.Add(temporalCustomer);
            }
            return Json(clientList);
        }

        public async Task<IActionResult> PostPromoCode(PromoCodeInfo promoCodeInfo)
        {
            try
            {
                string InsertPromoQuery = "INSERT INTO AYT_PromoCodes (PromoCode, ItemsList, BlackList, ExpireDate, StartDate, SiteId, FamiliesSelected) " +
                    "VALUES ('" + promoCodeInfo.PromoCode + "','" + promoCodeInfo.ItemsList + "','', '" + String.Format("{0:yyyy-MM-dd}", promoCodeInfo.ExpireDate) + "', " +
                    "'" + String.Format("{0:yyyy-MM-dd}", promoCodeInfo.StartDate) + "', '" + promoCodeInfo.SiteId + "', '" + promoCodeInfo.FamiliesSelected + "')";
                await ProdConection.StartNonQuery(InsertPromoQuery);
                return Json(new { success = true, message = "Se generó el Código Promocional" });
            }catch(Exception e)
            {
                return Json(new { success = false, message = e.ToString() });
            }
        }

        public async Task<IActionResult> PromoCodeEnabler(int promoCodeId, int enabledStatus)
        {
            try
            {
                await ProdConection.StartNonQuery("UPDATE AYT_PromoCodes SET  Enabled = "+enabledStatus+" WHERE Id ="+promoCodeId);
                string message = enabledStatus == 0 ? "Se desactivó el Código Promocional" : "Se activó el Código Promocional";
                return Json(new { success = true, message });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e.ToString() });
            }
        }

        public async Task<IActionResult> UpdatePromoCode(PromoCodeInfo promoCodeInfo)
        {
            try
            {
                await ProdConection.StartNonQuery("UPDATE [dbo].[AYT_PromoCodes] SET " +
                    "PromoCode = '"+ promoCodeInfo.PromoCode + "', " +
                    "ItemsList = '"+ promoCodeInfo.ItemsList +"'," +
                    "StartDate = '" + String.Format("{0:yyyy-MM-dd}", promoCodeInfo.StartDate) + "'," +
                    "ExpireDate = '" + String.Format("{0:yyyy-MM-dd}", promoCodeInfo.ExpireDate) + "', " +
                    "SiteId = '"+ promoCodeInfo.SiteId +"', " +
                    "FamiliesSelected =  '"+ promoCodeInfo.FamiliesSelected + "'"+
                    "WHERE Id ="+ promoCodeInfo.Id);
                return Json(new { success = true, message = "Se actualizó el Código Promocional" });
            }catch(Exception e)
            {
                return Json(new { success = false, message = e.ToString() });
            }
        }
    public async Task<IActionResult> GetItemsFamily(Dictionary<int, string> familyList)
    {
        List<ArticleInfo> articlesList = new List<ArticleInfo>();
        string lastFamilyString = familyList.Values.Last();
      string familyToQuery = "";
      foreach (string family in familyList.Values)
      {
        if (family == lastFamilyString)
        {
          familyToQuery += "'" + family + "'";
        }
        else
        {
          familyToQuery += "'" + family + "',";
        }
      }
      //Console.WriteLine(familyToQuery);
      //string queryString = "SELECT DISTINCT (T1.ITEMNUMBER) AS 'CODIGO' " +
      //", IIF((T5.DESCRIPTION = '' OR T5.DESCRIPTION IS NULL ), T1.ProductSearchName,T5.DESCRIPTION) AS NOMBRE " +
      //" FROM EcoResReleasedProductV2Staging T1 " +
      //" LEFT JOIN EcoResProductCategoryAssignmentStaging T4 ON(T4.PRODUCTNUMBER COLLATE DATABASE_DEFAULT = T1.ITEMNUMBER COLLATE DATABASE_DEFAULT AND T4.PRODUCTCATEGORYHIERARCHYNAME COLLATE DATABASE_DEFAULT = 'FAMILIA') " +
      //" LEFT JOIN AYT_InventTableStaging T5 ON(T5.ITEMID COLLATE DATABASE_DEFAULT = T1.ItemNumber COLLATE DATABASE_DEFAULT) " +
      //" WHERE T4.PRODUCTCATEGORYNAME IN(" + familyToQuery + ") AND T5.DESCRIPTION != 'DESCONTINUADO' AND T5.PRODUCTLIFECYCLESTATEID != 'INACTIVO'" +
      //" ORDER BY CODIGO;";
      string queryString = "SELECT DISTINCT(T0.ItemNumber) AS CODIGO, T0.ProductSearchName AS NOMBRE " +
"FROM articulos T0 " +
"LEFT JOIN AYT_PorcentajeUtilidadFamilia T1 ON (T0.ItemNumber = T1.ITEMNUMBER) " +
"WHERE T1.FAMILIA IN (" + familyToQuery + ");";
      SqlDataReader articlesReader = await AYT03Conection.GetReader(queryString);
      //Console.WriteLine(articlesReader.Cast<object>().Count());
      while (articlesReader.Read())
      {
        ArticleInfo temporalArticle = new ArticleInfo
        {
          ItemNumber = articlesReader.GetString(0),
          SearchName = articlesReader.GetString(1)
        };
        articlesList.Add(temporalArticle);
      }
      return Json(new { success = false, message = articlesList });
    }
  }
    public class ClientJsonReturn
    {
        public string id { get; set; }
        public string text { get; set; }
    }
}