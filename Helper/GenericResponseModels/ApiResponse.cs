using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Educa.Helper.GenericResponseModels
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T ResultData { get; set; }

        public ApiResponse(bool Success, string Message, T Result)
        {
            this.Success = Success;
            this.Message = Message;
            this.ResultData = Result;
        }
    }

    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ResultData { get; set; }

        public ApiResponse(bool Success, string Message)
        {
            this.Success = Success;
            this.Message = Message;
            this.ResultData = null;
        }
    }
}
