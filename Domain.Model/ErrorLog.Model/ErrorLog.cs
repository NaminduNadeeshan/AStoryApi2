using System;
namespace Domain.Model.ErrorLog.Model
{
    public class ErrorLog
    {
        public string ErrorFile { get; set; }

        public string ErrorFunction { get; set; }

        public string errorException { get; set;}
    }
}
