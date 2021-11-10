using InaxCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaxCore.Helpers.DynamicsHelpers
{
    public class DiaryCreationHelper
    {

        public static async Task<string> CreateDiary(DiaryModel diaryRequest)
        {
            diaryRequest.DiaryCode = await CreateDiaryHeader(diaryRequest);
            if(!string.IsNullOrEmpty(diaryRequest.DiaryCode))
            {
                if (await SetDiarySingleLine(diaryRequest))
                {
                    if(await RegisterDiary(diaryRequest.DiaryCode, diaryRequest.DataAreaId))
                    {
                        return diaryRequest.DiaryCode;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public static async Task<string> CreateDiaryHeader(DiaryModel diary)
        {
            string postHeaderJson = "{\n\t \t\t\"dataAreaId\": \""+diary.DataAreaId+"\",\n      \"JournalName\": \""+diary.JournalName+"\",\n      \"Description\": \"\"\n}";
            HeaderJsonResponse headerResponse = JsonConvert.DeserializeObject<HeaderJsonResponse>(await OdataConection.PostQueryJson("/data/CustomerPaymentJournalHeaders", postHeaderJson));
            DateTime timeNow = DateTime.Now;
            string description = timeNow.ToShortDateString()+", "+diary.CreatorUser+", "+diary.Ov+", "+headerResponse.JournalBatchNumber+", "+diary.PayReference;
            string patchHeaderJson = "{\"Description\": \""+description+"\"\n}";
            string patchResponse = await OdataConection.PatchQueryJson("/data/CustomerPaymentJournalHeaders(dataAreaId='" + diary.DataAreaId + "',JournalBatchNumber='" + headerResponse.JournalBatchNumber + "')", patchHeaderJson);
            return headerResponse.JournalBatchNumber;
        }

        public static async Task<bool> SetDiarySingleLine(DiaryModel diary)
        {
            DateTime timeNow = DateTime.Now;
            string description = timeNow.ToShortDateString() + ", " + diary.CreatorUser + ", " + diary.Ov + ", " + diary.DiaryCode;
            string postLineJson = "{\n\t \t\t\"dataAreaId\": \""+diary.DataAreaId+"\",\n\t\t\t\"LineNumber\": 1,\n      \"JournalBatchNumber\": \""+diary.DiaryCode+"\",\n\t\t\t\"OffsetAccountType\": \"Bank\",\n\t\t\t\"" +
                "PaymentReference\": \""+diary.Ov+"\",\n\t\t\t\"STF_RefSalesId\": \""+diary.Ov+"\",\n\t\t\t\"AccountDisplayValue\": \"\",\n\t\t\t\"OffsetAccountDisplayValue\": \""+diary.DiarioCuentaContra+"\",\n\t \t\t\"CreditAmount\": " + diary.DiaryAmmount + ",\n\t\t\t\"" +
                "PaymentMethodName\": \"\",\n\t\t\t\"TransactionText\": \""+description+"\",\n\"CurrencyCode\": \"MXN\"\n}";
            string response = await OdataConection.PostQueryJson("/data/CustomerPaymentJournalLines", postLineJson);
            string patchCustomerJson = "{\"AccountDisplayValue\": \""+diary.ClientCode+"\"}";
            string patchResponse = await OdataConection.PatchQueryJson("/data/CustomerPaymentJournalLines(dataAreaId=%27" + diary.DataAreaId + "%27,LineNumber=1,JournalBatchNumber=%27" + diary.DiaryCode + "%27)", patchCustomerJson);
            return true;
        }
        public static async Task<bool> RegisterDiary(string diaryCode, string company)
        {
            string postRegisterJson = "{\n\t\"journal\": \"" + diaryCode + "\",\n\t\"company\": \"" + company + "\"\n}";
            string response = await OdataConection.PostQueryJson("/api/services/STF_INAX/STF_DiariosPagos/postPaymentJournal", postRegisterJson);
            return true;
        }
    }

    public class HeaderJsonResponse
    {
        public string JournalBatchNumber { get; set; }
    }

}
