using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.BasicCOAs.Queries.RequestResponseModel
{
    public class BasicCOARM : IMapFrom<BasicCOA>
    {
        public decimal ID { get; set; }
        public string DESCRIPTION { get; set; }
        public string AccountCode { get; set; }
        public int? ParentID { get; set; }
        public int LevelID { get; set; }
        public byte Status { get; set; }
        public DateTime RDATE { get; set; }
        public long NaturalAccountID { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<BasicCOARM, BasicCOA>().ReverseMap();
        }
    }
}
