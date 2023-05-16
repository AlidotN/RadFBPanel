using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using radFB.Models;

namespace EShop_AspCore.Services
{
    public class SmsService
    {
        //public static bool SendSms(string linNumber, string MobileNo, string message)
        //{
        //    ApplicationDbContext database = new ApplicationDbContext();
        //    var q = database.Tbl_siteSetting.FirstOrDefault();
        //    SmsIrRestful.Token tokenInstance = new SmsIrRestful.Token();

        //    var token = tokenInstance.GetToken(q.SmsApiService, q.SmsSecretKey);

        //    SmsIrRestful.MessageSend messageInstance = new SmsIrRestful.MessageSend();
        //    var res = messageInstance.Send(token, new SmsIrRestful.MessageSendObject()
        //    {
        //        CanContinueInCaseOfError = false,
        //        LineNumber = linNumber,
        //        Messages = new List<string> { message }.ToArray(),
        //        MobileNumbers = new List<string> { MobileNo }.ToArray(),
        //        SendDateTime = DateTime.Now,
        //    });

        //    if (res.IsSuccessful == true)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
