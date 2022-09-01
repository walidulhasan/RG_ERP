using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.AlgoHR;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Leavess.Query.RequestResponseModel
{
    public class Tbl_LeavesRM:IMapFrom<Tbl_Leaves>
    {
        public int Leaves_ID { get; set; }
        public string Leaves_Desc { get; set; }
        public bool? Leaves_Lapse { get; set; }
        public bool? Leaves_Encash { get; set; }
        public short? Leaves_Days { get; set; }
        //public short? Leaves_Type { get; set; }
        //public DateTime? Leaves_Created { get; set; }
        //public string Leave_PCode { get; set; }
        public string Leave_Legend { get; set; }
        public bool Leave_UserDefinedOpeningBalance { get; set; }
        public string Leave_Gender { get; set; }
        public int MaxAvailDaysAtATime { get; set; }
        public bool IsDocumentRequired { get; set; }
        public int? DocumentRequiredForMoreThanDays { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tbl_Leaves, Tbl_LeavesRM>();
        }
    }
}
