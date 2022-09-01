using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.ApplicationDocumentss.Queries.RequestResponseModel
{
    public class ApplicationDocumentsRM
    {
        public int DocumentID { get; set; }
        public int ApplicationID { get; set; }
        public int DocumentTypeID { get; set; }
        public string DocumentType { get; set; }
        public string DocumentPath { get; set; }
        public string FileType { get; set; }
    }
}
