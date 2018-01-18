using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeysoHomeWeb.WebCommon
{
    public class ResultModel
    {
        public ResultModel(string resultCode, string message)
        {
            ResultCode = resultCode;
            Message = message;
        }

        public string ResultCode { get; set; }

        public string Message { get; set; }
    }
}