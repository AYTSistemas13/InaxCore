using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaxCore.Models.StaticInfo
{
    public static class StaticExhangeRate
    {
        public static DateTime LastUpdated { get; set; }
        public static string Rate { get; set; }

        public static TimeSpan UpdateTimeSpan = new TimeSpan(0, 30, 0);

        public static async Task<string> GetRate()
        {
            ExchangeRate exchangeRate = new ExchangeRate();
            if (DateTime.Now.Subtract(LastUpdated) > UpdateTimeSpan)
            {
                string exchangeQuery = "ExchangeRates?%24select=Rate&%24filter=StartDate%20eq%202020-03-02T12%3A00%3A00Z";
                exchangeRate.Rate = JsonConvert.DeserializeObject<ExchangeJsonObject>(await OdataConection.QueryJson(exchangeQuery)).Value[0].Rate;
                Rate = exchangeRate.Rate;
                LastUpdated = DateTime.Now;
            }
            else
            {
                exchangeRate.Rate = Rate;
            }
            return exchangeRate.Rate;
        }
    }
    public class ExchangeJsonObject
    {
        public Dictionary<string, string> @Odatacontext { get; set; }
        public List<ExchangeRate> Value { get; set; }
    }
}
