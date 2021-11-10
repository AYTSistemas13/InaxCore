using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaxCore.Models
{
    public class PromoCodeInfo
    {
        public long Id { get; set; }
        public String PromoCode { get; set; }
        public String ItemsList { get; set; }
        public String BlackList { get; set; }
        public bool Expires { get; set; }
        public bool Enabled { get; set; }
        public string SiteId { get; set; }
        public int MaxRedeemed { get; set; }
        public int Redeemed { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime StartDate { get; set; }
        public String FamiliesSelected { get; set; }
    }
}
