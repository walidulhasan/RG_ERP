using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class CMBL_POQuotationFileUpload
    {
        public long POAttachmentID { get; set; }
        public long POID { get; set; }
        public DateTime UploadDate { get; set; }
        public int FileSerial { get; set; }
        public string Comments { get; set; }
        public string FileName { get; set; }
        public string FileUri { get; set; }
    }
}
