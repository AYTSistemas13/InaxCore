using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaxCore.Helpers.DynamicsHelpers
{
    public class ReleaseOv
    {
        public static async Task<bool> Release(string Ov) {
            string jsonString = "{'salesId' : '" + Ov + "', 'company' : 'ATP'}";
            string response = await OdataConection.PostQueryJson("/api/services/STF_INAX/STF_LiberacionOV/releaseToWarehouseV2", jsonString);
            WorkJsonResponse works = JsonConvert.DeserializeObject<WorkJsonResponse>(await OdataConection.QueryJson("STF_WHSWorkLineEntity?%24filter=OrderNum%20eq%20'" + Ov + "'"));
            if(works.Value.Count > 0)
            {
                if(string.IsNullOrEmpty(works.Value[0].WorkId))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }

    public  class WorkJsonResponse
    {
        public List<WorkObject> Value { get; set; }
    }

    public class WorkObject
    {
        public string WorkId { get; set; }
    }
}
