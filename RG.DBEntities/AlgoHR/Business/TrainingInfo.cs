using System.Collections.Generic;

namespace RG.DBEntities.AlgoHR.Business
{
    public class TrainingInfo : DefaultTableProperties
    {
        public TrainingInfo()
        {
            TrainingDocuments = new List<TrainingDocuments>();
        }
        public int ID { get; set; }
        public int TrainingTypeID { get; set; }
        public string TrainingName { get; set; }
        public string TrainingDescription { get; set; }
        public virtual List<TrainingDocuments> TrainingDocuments { get; set; }
    }
}
