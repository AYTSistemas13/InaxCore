using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using InaxCore.Helpers.DynamicsHelpers;
using InaxCore.Helpers.SqlConections;
using InaxCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InaxCore.Controllers
{
    [Route("[controller]")]
    public class CreditRequestsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            SqlDataReader creditRequestReader = await ProdConection.GetReader("SELECT * FROM [dbo].[AYT_CreditRequest]");
            List<CreditRequestModel> creditRequestList = new List<CreditRequestModel>();
            while (creditRequestReader.Read())
            {
                CreditRequestModel temporalRequest = new CreditRequestModel
                {
                    Id = creditRequestReader.GetInt32(0),
                    Ov = creditRequestReader.GetString(1),
                    RequestType = creditRequestReader.GetInt32(2),
                    ClientCode = creditRequestReader.GetString(3),
                    ClientName = creditRequestReader.GetString(4),
                    OrderTakerCode = creditRequestReader.GetString(5),
                    InsertDate = creditRequestReader.GetDateTime(8),
                    Status = creditRequestReader.GetInt32(10),
                    OvAmmount = creditRequestReader.GetDouble(14),
                    OrderTakerName = creditRequestReader.GetString(15),
                    Zone = creditRequestReader.GetString(16),
                };
                if (temporalRequest.Status == 1)
                {
                    temporalRequest.DiaryCode = temporalRequest.RequestType == 2 ? creditRequestReader.GetString(9) : "";
                    temporalRequest.WorkedBy = creditRequestReader.GetString(6);
                    temporalRequest.WorkedOn = creditRequestReader.GetDateTime(7);
                }
                if (temporalRequest.Status == 4)
                {
                    temporalRequest.DiaryCode = "";
                    temporalRequest.WorkedBy = creditRequestReader.GetString(6);
                    temporalRequest.WorkedOn = creditRequestReader.GetDateTime(7);
                }
                creditRequestList.Add(temporalRequest);
            }
            return View(creditRequestList);
        }

        [AllowAnonymous]
        [Route("[action]/{requestId}")]
        public async Task<IActionResult> CreditRequest(int requestId)
        {
            SqlDataReader creditRequestReader = await ProdConection.GetReader("SELECT * FROM [dbo].[AYT_CreditRequest] WHERE Id = " + requestId);
            SqlDataReader creditReqAttachmentsReader = await ProdConection.GetReader("SELECT * FROM [dbo].[AYT_CreditReqAttachments] WHERE RequestId = " + requestId + " ORDER BY Id");
            CreditRequestModel creditRequest = new CreditRequestModel();
            List<CreditReqAttachmentModel> requestAttachments = new List<CreditReqAttachmentModel>();
            while (creditReqAttachmentsReader.Read())
            {
                CreditReqAttachmentModel temporalAttachment = new CreditReqAttachmentModel
                {
                    Id = creditReqAttachmentsReader.GetInt32(0),
                    AttachmentType = creditReqAttachmentsReader.GetInt32(2),
                    Ov = creditReqAttachmentsReader.GetString(3),
                    Message = creditReqAttachmentsReader.GetString(4),
                    FileUrl = creditReqAttachmentsReader.GetString(5),
                    InsertDate = creditReqAttachmentsReader.GetDateTime(6),
                    MessageFrom = creditReqAttachmentsReader.GetInt32(7)
                };
                requestAttachments.Add(temporalAttachment);
            }
            while (creditRequestReader.Read())
            {
                creditRequest = new CreditRequestModel
                {
                    Id = creditRequestReader.GetInt32(0),
                    Ov = creditRequestReader.GetString(1),
                    RequestType = creditRequestReader.GetInt32(2),
                    ClientCode = creditRequestReader.GetString(3),
                    ClientName = creditRequestReader.GetString(4),
                    OrderTakerCode = creditRequestReader.GetString(5),
                    InsertDate = creditRequestReader.GetDateTime(8),
                    OvAmmount = creditRequestReader.GetDouble(14),
                    OrderTakerName = creditRequestReader.GetString(15),
                    Zone = creditRequestReader.GetString(16),
                };
            }
            ViewData["requestAttachments"] = requestAttachments;
            return View(creditRequest);
        }

        [Route("[action]")]
        public async Task<IActionResult> UploadFiles(CreditReqAttachmentModel creditReqInfo)
        {
            creditReqInfo.Files = Request.Form.Files;
            Console.WriteLine(creditReqInfo);
            SqlDataReader currentFilesReader = await ProdConection.GetReader("SELECT COUNT(Id) FROM [dbo].[AYT_CreditReqAttachments] WHERE RequestId = " + creditReqInfo.RequestId);
            int fileIndex = 1;
            while (currentFilesReader.Read())
            {
                fileIndex = currentFilesReader.GetInt32(0) + 1;
            }

            foreach (IFormFile file in creditReqInfo.Files)
            {
                string[] fileExtension = file.FileName.Split(".");
                string filePath = "/img/CreditRequestImg/" + creditReqInfo.Ov + "-" + fileIndex + "." + fileExtension.Last();
                using (var stream = System.IO.File.Create("./wwwroot" + filePath))
                {
                    await file.CopyToAsync(stream);
                }
                await ProdConection.StartNonQuery("INSERT INTO [dbo].[AYT_CreditReqAttachments] (RequestId, AttachmentType, Ov, FileUrl) " +
                    "VALUES ('" + creditReqInfo.RequestId + "', 1, '" + creditReqInfo.Ov + "', '" + filePath + "' )");
                fileIndex++;
            }
            return Ok();
        }

        [Route("[action]")]
        public async Task<IActionResult> PostMessage(CreditReqAttachmentModel creditReqInfo)
        {
            string insertQuery = "INSERT INTO [dbo].[AYT_CreditReqAttachments] (RequestId, AttachmentType, Ov, Message, MessageFrom) " +
                     "VALUES ('" + creditReqInfo.RequestId + "', 2, '" + creditReqInfo.Ov + "', '" + creditReqInfo.Message + "', '" + creditReqInfo.MessageFrom + "' )";
            await ProdConection.StartNonQuery(insertQuery);
            return Ok();
        }

        [Route("[action]")]
        public async Task<IActionResult> GetAttachments(int requestId)
        {
            SqlDataReader creditReqAttachmentsReader = await ProdConection.GetReader("SELECT * FROM [dbo].[AYT_CreditReqAttachments] WHERE RequestId = " + requestId + " ORDER BY Id");
            List<CreditReqAttachmentModel> requestAttachments = new List<CreditReqAttachmentModel>();
            while (creditReqAttachmentsReader.Read())
            {
                CreditReqAttachmentModel temporalAttachment = new CreditReqAttachmentModel
                {
                    Id = creditReqAttachmentsReader.GetInt32(0),
                    AttachmentType = creditReqAttachmentsReader.GetInt32(2),
                    Ov = creditReqAttachmentsReader.GetString(3),
                    Message = creditReqAttachmentsReader.GetString(4),
                    FileUrl = creditReqAttachmentsReader.GetString(5),
                    InsertDate = creditReqAttachmentsReader.GetDateTime(6),
                    MessageFrom = creditReqAttachmentsReader.GetInt32(7)
                };
                requestAttachments.Add(temporalAttachment);
            }

            return Json(requestAttachments);
        }

        [Route("[action]")]
        public async Task<IActionResult> ReleaseToWarehouse(string Ov, int RequestId)
        {
            bool beenReleased = await ReleaseOv.Release(Ov);
            string userProcessor = User.Identity.Name.Split("@").First();
            if (beenReleased)
            {
                await ProdConection.StartNonQuery("UPDATE [dbo].[AYT_CreditRequest] " +
                        "SET [WorkedBy] = '" + userProcessor + "', " +
                        "[WorkedOn] = getdate(), " +
                        "[LiberatedOn] = getdate(), " +
                        "[Status] = 1" +
                        "WHERE Id =" + RequestId);
                return Json(new { success = true, message = Ov + " Liberada Exitosamente" });
            }
            else
            {
                return Json(new { success = false, message = "No se pudo Liberar la Ov" });
            }
        }

        [Route("[action]")]
        public async Task<IActionResult> CreateDiary(DiaryModel diaryToCreate)
        {
            diaryToCreate.CreatorUser = User.Identity.Name.Split("@").First();
            SqlDataReader hasDiaryReader = await ProdConection.GetReader("SELECT DiaryCode FROM [dbo].[AYT_CreditRequest] WHERE Id = " + diaryToCreate.RequestId + " AND DiaryCode IS NOT NULL");
            if (hasDiaryReader.HasRows)
            {
                while (hasDiaryReader.Read())
                {
                    diaryToCreate.DiaryCode = hasDiaryReader.GetString(0);
                }
            }
            else
            {
                diaryToCreate.DiaryCode = await DiaryCreationHelper.CreateDiary(diaryToCreate);
            }
            if (!string.IsNullOrEmpty(diaryToCreate.DiaryCode))
            {
                if (await ReleaseOv.Release(diaryToCreate.Ov))
                {
                    await ProdConection.StartNonQuery("UPDATE [dbo].[AYT_CreditRequest] " +
                        "SET [WorkedBy] = '" + diaryToCreate.CreatorUser + "', " +
                        "[WorkedOn] = getdate(), " +
                        "[DiaryOn] = getdate(), " +
                        "[LiberatedOn] = getdate(), " +
                        "[Status] = 1," +
                        "[DiaryCode] = '" + diaryToCreate.DiaryCode + "' " +
                        "WHERE Id =" + diaryToCreate.RequestId);
                    return Json(new { success = true, message = "Diario creado correctamente: " + diaryToCreate.DiaryCode + " y Liberado exitosamente!" });
                }
                else
                {
                    await ProdConection.StartNonQuery("UPDATE [dbo].[AYT_CreditRequest] " +
                        "SET [WorkedBy] = '" + diaryToCreate.CreatorUser + "', " +
                        "[WorkedOn] = getdate(), " +
                        "[DiaryOn] = getdate(), " +
                        "[Status] = 3," +
                        "[DiaryCode] = '" + diaryToCreate.DiaryCode + "' " +
                        "WHERE Id =" + diaryToCreate.RequestId);
                    return Json(new { success = false, message = "Diario creado correctamente: " + diaryToCreate.DiaryCode + " pero no se pudo liberar!" });
                }
            }
            else
            {
                return Json(new { success = false, message = "No se pudo generar diario" });
            }
        }

        [Route("[action]")]
        public async Task<IActionResult> DenyRequest(int RequestId)
        {
            string userProcessor = User.Identity.Name.Split("@").First();
            await ProdConection.StartNonQuery("UPDATE [dbo].[AYT_CreditRequest] " +
                        "SET [WorkedBy] = '" + userProcessor + "', " +
                        "[WorkedOn] = getdate(), " +
                        "[Status] = 4" +
                        "WHERE Id =" + RequestId);
            return Json(new { success = true, message = "La solicitud fue negada correctamente" });
        }

    }
}