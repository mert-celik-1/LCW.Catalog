using System;
using System.Collections.Generic;
using System.Text;

namespace LCW.Catalog.Shared.Response
{
    public class NoDataResponse
    {
        public NoDataResponse(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public NoDataResponse(ResultStatus resultStatus, string message)
        {
            ResultStatus = resultStatus;
            Message = message;
        }
        public NoDataResponse(ResultStatus resultStatus, string message, Exception exception)
        {
            ResultStatus = resultStatus;
            Message = message;
            Exception = exception;
        }
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
