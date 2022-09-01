using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Setup
{
    public class UploadedDocumentType : DefaultTableProperties
    {
        public int DocumentTypeID { get; set; }
        public string DocumentType { get; set; }
        public string ModuleName { get; set; }
    }
}
