using System;
using System.Web.Mvc;
using ELL.Models.Globals;
using ELL.Services;

namespace ELL.Controllers
{
    public class ELLBaseController : Controller
    {
        public LoggerService Logger;
        //public TimeZoneInfo CurrentTimeZone;

        public ELLBaseController()
        {
            Logger = new LoggerService();
            //CurrentTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        }


        public void Attention(string message)
        {
            if (TempData.ContainsKey(Alerts.ATTENTION) == false)
            {
                TempData.Add(Alerts.ATTENTION, message);
            }
        }

        public void Success(string message)
        {
            if (TempData.ContainsKey(Alerts.SUCCESS) == false)
            {
                TempData.Add(Alerts.SUCCESS, message);
            }
        }

        public void Information(string message)
        {
            if (TempData.ContainsKey(Alerts.INFORMATION) == false)
            {
                TempData.Add(Alerts.INFORMATION, message);
            }
        }

        public void Error(string message)
        {
            if (TempData.ContainsKey(Alerts.ERROR) == false)
            {
                TempData.Add(Alerts.ERROR, message);
            }
        }

    }


}