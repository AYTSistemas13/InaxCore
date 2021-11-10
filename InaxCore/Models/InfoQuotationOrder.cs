using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaxCore.Models
{
    public class InfoQuotationOrder
    {
        public string SalesQuotationNumber { get; set; }
        public string DefaultShippingSiteId { get; set; }
        public string InvoiceCustomerAccountNumber { get; set; }
        public string SalesQuotationStatus { get; set; }
        public string ReceiptDateRequested { get; set; }
        public string DeliveryModeCode { get; set; }
        public string DefaultShippingWarehouseId { get; set; }
        public string SalesQuotationName { get; set; }
    }
}
