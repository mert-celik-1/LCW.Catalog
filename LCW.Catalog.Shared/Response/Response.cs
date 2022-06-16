using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LCW.Catalog.Shared.Response
{
    public class Response<T>
    {
        public Response(ResultStatus resultStatus, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }
        public Response(ResultStatus resultStatus, string message, T data)
        {
            ResultStatus = resultStatus;
            Message = message;
            Data = data;
        }
        public Response(ResultStatus resultStatus, string message)
        {
            ResultStatus = resultStatus;
            Message = message;
        }

        public Response(ResultStatus resultStatus, List<string> messages)
        {
            ResultStatus = resultStatus;
            Messages = messages;
        }

        public Response(ResultStatus resultStatus, string message, T data, Exception exception)
        {
            ResultStatus = resultStatus;
            Message = message;
            Data = data;
            Exception = exception;
        }
        public ResultStatus ResultStatus { get; }

        public string Message { get; }
        [JsonIgnore]
        public List<string> Messages { get; }
        [JsonIgnore]
        public Exception Exception { get; }
        public T Data { get; }
    }
}
