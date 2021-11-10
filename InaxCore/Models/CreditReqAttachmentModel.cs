using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InaxCore.Models
{
    public class CreditReqAttachmentModel
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int AttachmentType { get; set; }
        public string Ov { get; set; }
        public string Message { get; set; }
        public string FileUrl { get; set; }
        public int MessageFrom { get; set; }
        public DateTime InsertDate { get; set; }
        [JsonIgnore]
        public IFormFileCollection Files { get; set; }
    }
}
