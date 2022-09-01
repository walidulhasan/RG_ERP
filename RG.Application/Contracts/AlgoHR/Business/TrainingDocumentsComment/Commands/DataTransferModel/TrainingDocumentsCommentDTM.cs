using RG.Application.Common.Mappings;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.TrainingDocumentsComment.Commands.DataTransferModel
{
    public class TrainingDocumentsCommentDTM : IMapFrom<TrainingDocumentsComments>
    {
        public int DocumentsID { get; set; }
        public string Comments { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<TrainingDocumentsCommentDTM, TrainingDocumentsComments>().ReverseMap();
        }
    }
}
