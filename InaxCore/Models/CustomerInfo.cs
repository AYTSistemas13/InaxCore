using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaxCore.Models
{
    public class CustomerInfo
    {
        public string CustomerAccount { get; set; }
        public string OrganizationName { get; set; }
        public string SiteId { get; set; }
        public string DeliveryMode { get; set; }
        public string DeliveryTerms { get; set; }
        public string FullPrimaryAddress { get; set; }
        public string PaymentBankAccount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentTerms { get; set; }
        public string RFCNumber { get; set; }
        public string PrimaryContactPhone { get; set; }
        public string PrimaryContactEmail { get; set; }
        public double CreditLimit { get; set; }
        public string CustomerGroupId { get; set; }
        public string PartyNumber { get; set; }
        public string LineDiscountCode { get; set; }
        public string DiscountPriceGroupId { get; set; }
    }
}
