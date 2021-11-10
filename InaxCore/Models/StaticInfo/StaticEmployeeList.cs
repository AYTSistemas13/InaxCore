using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaxCore.Models.StaticInfo
{
    public class StaticEmployeeList
    {
        public static DateTime LastUpdated { get; set; }
        public static List<EmployeeInfo> EmployeeList { get; set; }

        public static TimeSpan UpdateTimeSpan = new TimeSpan(0, 20, 0);

        public static async Task<List<EmployeeInfo>> GetEmployeeInfoList()
        {
            List<EmployeeInfo> employeeList = new List<EmployeeInfo>();
            if (DateTime.Now.Subtract(LastUpdated) > UpdateTimeSpan)
            {
                string employeeListQuery = "Employees?%24select=PersonnelNumber,Name";
                employeeList = JsonConvert.DeserializeObject<EmployeeListJsonObject>(await OdataConection.QueryJson(employeeListQuery)).Value;
                EmployeeList = employeeList;
                LastUpdated = DateTime.Now;
            }
            else
            {
                employeeList = EmployeeList;
            }
            return employeeList;
        }
    }
    public class EmployeeListJsonObject
    {
        public Dictionary<string, string> @odatacontext { get; set; }
        public List<EmployeeInfo> Value { get; set; }
    }
}
