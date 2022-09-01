using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Queries.RequestResponseModel
{
    public class TrainingDocumentsRM
    {
        public int ID { get; set; }
        public int TriningID { get; set; }
        public int DocumentTypeID { get; set; }
        public string DocumentType { get; set; }
        public int FileSerial { get; set; }
        public string FileTitle { get; set; }
        public string FileExtension { get; set; }
        public string FileUrl { get; set; }
        public bool IsExternalFile { get; set; }
    }
}
