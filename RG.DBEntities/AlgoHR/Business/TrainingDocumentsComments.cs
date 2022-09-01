using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Business
{
    public class TrainingDocumentsComments:DefaultTableProperties
    {
        public long ID { get; set; }
        public int DocumentsID { get; set; }
        public string Comments { get; set; }
    }
}
