using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Business
{
    public class TrainingType : DefaultTableProperties
    {
        public int ID { get; set; }
        public string TrainingTypeName { get; set; }
        public string TrainingTypeDescription { get; set; }
    }
}
