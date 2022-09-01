using RG.Application.Common.Mappings;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Queries.RequestResponseModel
{
    public class TrainingInfoRM:IMapFrom<TrainingInfo>
    {
        public TrainingInfoRM()
        {
            TrainingDocuments = new List<TrainingDocumentsRM>();
        }
        public int ID { get; set; }
        public int TrainingTypeID { get; set; }
        public string TrainingTypeName { get; set; }
        public string TrainingName { get; set; }
        public string TrainingDescription { get; set; }
        public int NoOfDocuments { get; set; }
        public List<TrainingDocumentsRM> TrainingDocuments { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<TrainingInfo, TrainingInfoRM>();
        }
    }

}
