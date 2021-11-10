using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaxCore.Models
{
    public class DiaryModel
    {
        public string Ov { get; set; }
        public int RequestId { get; set; }
        public string JournalName { get; set; }
        public string Description { get; set; }
        public string DataAreaId { get; set; }
        public string DiaryAmmount { get; set; }
        public string DiarioCuentaContra { get; set; }
        public string DiarioFPago { get; set; }
        public string TipoPago { get; set; }
        public string PayReference { get; set; }
        public string DiaryCode { get; set; }
        public string ClientCode { get; set; }
        public string CreatorUser { get; set; }
    }
}
