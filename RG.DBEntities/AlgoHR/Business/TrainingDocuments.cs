using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Business
{
    public class TrainingDocuments : DefaultTableProperties
    {
        
        public int ID { get; set; }
        [ForeignKey("TrainingInfo")]
        public int TriningID { get; set; }
        public int DocumentTypeID { get; set; }
        public int FileSerial { get; set; }
        public string FileTitle { get; set; }
        public string FileExtension { get; set; }
        public string FileUrl { get; set; }
        public bool IsExternalFile { get; set; }
        public virtual TrainingInfo TrainingInfo { get;set;}

    }
}
