using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaxCore.Models
{
    public class CreditRequestModel
    {
        public int Id { get; set; }
        public string Ov { get; set; }
        public int RequestType { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string OrderTakerCode { get; set; }
        public string WorkedBy { get; set; }
        public DateTime WorkedOn { get; set; }
        public DateTime InsertDate { get; set; }
        public string DiaryCode { get; set; }
        public int Status { get; set; }
        public DateTime? LiberatedOn { get; set; }
        public DateTime? DiaryOn { get; set; }
        public string FilesArray { get; set; }
        public double OvAmmount { get; set; }
        public string OrderTakerName { get; set; }
        public string Zone { get; set; }
    }
}
