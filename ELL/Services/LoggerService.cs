using ELL.DBContext;
using ELL.Models.Log;
using System;
using System.Data.Entity;
using System.Diagnostics;
using static ELL.Enums.Enums;

namespace FXWell.Service
{
    public class LoggerService 
    {
        public void SaveToDB(string message, ELLLogType type, string stacktrace = "", string objectString = "")
        {
            TimeZoneInfo currentTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime dateNow = TimeZoneInfo.ConvertTime(DateTime.Now, currentTimeZone);


            using (ELLDBContext db = new ELLDBContext())
            {
                ELLLog ex = new ELLLog()
                {
                    DateCreated = dateNow,
                    Message = message,
                    Type = type,
                    Stacktrace = stacktrace,
                    ObjectString = objectString
                };

                db.Entry(ex).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        //
        // Warning - trace information within the application

        public void Information(string message, string stacktrace = "", string objectString = "", bool saveToDBFlag = true)
        {
            Trace.TraceInformation(message);

            if (saveToDBFlag)
            {
                SaveToDB(message, ELLLogType.Information, stacktrace, objectString);
            }
        }

        //
        // Warning - trace warnings within the application

        public void Warning(string message, string stacktrace = "", string objectString = "", bool saveToDBFlag = true)
        {
            Trace.TraceWarning(message);

            if (saveToDBFlag)
            {
                SaveToDB(message, ELLLogType.Warning, stacktrace, objectString);
            }
        }

        //
        // Error - trace fatal errors within the application

        public void Error(string message, string stacktrace = "", string objectString = "", bool saveToDBFlag = true)
        {
            Trace.TraceError(message);

            if (saveToDBFlag)
            {
                SaveToDB(message, ELLLogType.Error, stacktrace, objectString);
            }
        }

        //
        // TraceAPI - trace inter-service calls (including latency)

        public void TraceApi(string componentName, string method, TimeSpan timespan)
        {
            TraceApi(componentName, method, timespan, "");
        }

        public void TraceApi(string componentName, string method, TimeSpan timespan, string fmt, params object[] vars)
        {
            TraceApi(componentName, method, timespan, string.Format(fmt, vars));
        }

        public void TraceApi(string componentName, string method, TimeSpan timespan, string properties)
        {
            string message = String.Concat("component:", componentName, ";method:", method, ";timespan:", timespan.ToString(), ";properties:", properties);
            Trace.TraceInformation(message);
        }
    }
}