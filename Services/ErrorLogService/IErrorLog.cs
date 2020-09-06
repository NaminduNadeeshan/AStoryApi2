using System;
using Domain.Model.ErrorLog.Model;

namespace Services.ErrorLogService
{
    public interface IErrorLogService
    {
        void logErrorToServer(ErrorLog errorLog);
    }
}
