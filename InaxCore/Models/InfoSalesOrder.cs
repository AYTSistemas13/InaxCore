using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaxCore.Models
{
    public class InfoSalesOrder
    {
        public string SalesOrderNumber { get; set; }
        public string OrderTakerPersonnelNumber { get; set; }
        public string SalesOrderName { get; set; }
        public string ReleaseStatus { get; set; }
        public string SalesOrderStatus { get; set; }
        public string DeliveryModeCode { get; set; }
        public string DefaultShippingWarehouseId { get; set; }
        public string DefaultShippingSiteId { get; set; }
        public string InvoiceCustomerAccountNumber { get; set; }
        public string SalesMan { get; set; }
    }
}
