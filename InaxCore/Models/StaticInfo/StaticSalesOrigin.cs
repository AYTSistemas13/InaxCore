using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaxCore.Models.StaticInfo
{
    public static class StaticSalesOrigin
    {
        public static DateTime LastUpdated { get; set; }
        public static List<SalesOrigin> SalesOriginList { get; set; }

        public static TimeSpan UpdateTimeSpan = new TimeSpan(0, 30, 0);

        public static async Task<List<SalesOrigin>> GetSalesOriginList()
        {
            List<SalesOrigin> salesOriginList = new List<SalesOrigin>();
            if (DateTime.Now.Subtract(LastUpdated) > UpdateTimeSpan)
            {
                string salesOriginQuery = "STF_SalesOriginEntity";
                salesOriginList = JsonConvert.DeserializeObject<SalesOriginJsonObject>(await OdataConection.QueryJson(salesOriginQuery)).Value;
                SalesOriginList = salesOriginList;
                LastUpdated = DateTime.Now;
            }
            else
            {
                salesOriginList = SalesOriginList;
            }
            return salesOriginList;
        }
    }
    public class SalesOriginJsonObject
    {
        public Dictionary<string, string> @odatacontext { get; set; }
        public List<SalesOrigin> Value { get; set; }
    }


}
