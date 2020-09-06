using System;
using Domain.Model.ErrorLog.Model;

namespace Services.ErrorLogService
{
    public class ErrorLogService : IErrorLogService
    {
        public ErrorLogService()
        {
        }
        /// <summary>
        /// when a action fail this function make a database write
        /// </summary>
        /// <param name="errorLog"></param>
        public void logErrorToServer(ErrorLog errorLog)
        {
            //some database functions
        }
    }
}
