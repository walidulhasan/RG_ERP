using RG.Application.Common.Mappings;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Commands.DataTransferModel
{
    public class TrainingInfoDTM : IMapFrom<TrainingInfo>
    {
        public int ID { get; set; }
        public int TrainingTypeID { get; set; }
        public string TrainingName { get; set; }
        public string TrainingDescription { get; set; }
        public string TrainingDocumentsJson { get; set; }
        public List<TrainingDocumentsDTM> TrainingDocuments { get { return JsonSerializer.Deserialize<List<TrainingDocumentsDTM>>(TrainingDocumentsJson); } }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<TrainingInfoDTM, TrainingInfo>();
        }
    }
    public class TrainingDocumentsDTM:IMapFrom<TrainingDocuments>
    {
        public int DocumentTypeID { get; set; }
        public int FileSerial { get; set; }
        public string FileTitle { get; set; }
        public string FileExtension { get; set; }
        public string FileUrl { get; set; }
        public bool IsExternalFile { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<TrainingDocumentsDTM, TrainingDocuments>();
        }
    }
}
