using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaxCore.Models
{
    public class RedeemedCodeInfo
    {
        public long Id { get; set; }
        public string Cot { get; set; }
        public string PromoCode { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public DateTime InsertDate { get; set; }
       

    }
}
