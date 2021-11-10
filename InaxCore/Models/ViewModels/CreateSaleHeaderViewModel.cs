using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaxCore.Models.ViewModels
{
    public class CreateSaleHeaderViewModel
    {
        public List<SalesOrigin> SalesOriginList { get; set; }
        public List<EmployeeInfo> EmployeeInfoList { get; set; }
        public int HeaderIndex { get; set; }
    }
}
