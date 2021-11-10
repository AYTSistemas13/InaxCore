using InaxCore.Helpers.SqlConections;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InaxCore.Models.StaticInfo
{
    public static class StaticCustomerList
    {
        public static DateTime LastUpdated { get; set; }
        public static List<CustomerInfo> CustomerList { get; set; }

        public static TimeSpan UpdateTimeSpan = new TimeSpan(0,20,0);

        public static async Task<List<CustomerInfo>> GetCustomerList()
        {
            List<CustomerInfo> customerInfoList = new List<CustomerInfo>();
            if (DateTime.Now.Subtract(LastUpdated) > UpdateTimeSpan)
            {
                SqlDataReader allClientReader = await ProdConection.GetReader("SELECT * FROM clientesInax WHERE isBlocked = 'No' AND CustomerAccount IS NOT NULL");
                while (allClientReader.Read())
                {
                    CustomerInfo temporalCustomer = new CustomerInfo();
                    temporalCustomer.CustomerAccount = allClientReader.GetString(0);
                    temporalCustomer.OrganizationName = allClientReader.GetString(1);
                    temporalCustomer.SiteId = allClientReader.GetString(2);
                    temporalCustomer.DeliveryMode = allClientReader.IsDBNull(3) ? "" : allClientReader.GetString(3);
                    temporalCustomer.DeliveryTerms = allClientReader.GetString(4);
                    temporalCustomer.FullPrimaryAddress = allClientReader.GetString(5);
                    temporalCustomer.PaymentBankAccount = allClientReader.IsDBNull(6) ? "" : allClientReader.GetString(6);
                    temporalCustomer.PaymentMethod = allClientReader.IsDBNull(7) ? "" : allClientReader.GetString(7);
                    temporalCustomer.PaymentTerms = allClientReader.GetString(8);
                    temporalCustomer.RFCNumber = allClientReader.GetString(9);
                    temporalCustomer.PrimaryContactPhone = allClientReader.IsDBNull(10) ? "" : allClientReader.GetString(10);
                    temporalCustomer.PrimaryContactEmail = allClientReader.IsDBNull(11) ? "" : allClientReader.GetString(11);
                    temporalCustomer.CreditLimit = allClientReader.GetDouble(12);
                    temporalCustomer.CustomerGroupId = allClientReader.GetString(14);
                    temporalCustomer.PartyNumber = allClientReader.IsDBNull(15) ? "" : allClientReader.GetString(15);
                    temporalCustomer.LineDiscountCode = allClientReader.IsDBNull(16) ? "" : allClientReader.GetString(16);
                    temporalCustomer.DiscountPriceGroupId = allClientReader.IsDBNull(17) ? "" : allClientReader.GetString(17);
                    customerInfoList.Add(temporalCustomer);
                }
                CustomerList = customerInfoList;
                LastUpdated = DateTime.Now;
            }
            else
            {
                customerInfoList = CustomerList;
            }
            return customerInfoList;
        }
    }
}
