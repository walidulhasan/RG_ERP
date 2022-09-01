using System;

namespace RG.WEB.Models
{
    public class ErrorViewModel
    {
        public string ErrorTitle { get; set; }
        public string RequestId { get; set; }
        public string ExceptionMessage { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
