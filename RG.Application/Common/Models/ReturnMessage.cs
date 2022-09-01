using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Common.Models
{
   public static class ReturnMessage
    {
        public static string InsertMessage { get; set; } = "Created Successfully";
        public static string UpdateMessage { get; set; } = "Updated Successfully";
        public static string DeleteMessage { get; set; } = "Deleted Successfully";
        public static string ErrorMessage { get; set; } = "<b>Error Occoured</b>";
        public static string DuplicateMessage { get; set; } = "Duplicate Data Found";
        public static string InvalidModelMessage { get; set; } = "Model is not valid";
        public static string FileUploadMessage { get; set; } = "File Uploaded Successfully";
        public static string ApprovedMessage { get; set; } = "Approved Successfully";
        public static string NotApprovedMessage { get; set; } = "Not Approved ";
        public static string NoDataFound { get; set; } = "No Data Found";
    }
}
