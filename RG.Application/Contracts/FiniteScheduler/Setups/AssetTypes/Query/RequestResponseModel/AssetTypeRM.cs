using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Query.RequestResponseModel
{
    public class AssetTypeRM 
    {
        public int AssetTypeID { get; set; }
        public string TypeName { get; set; }
        public string Code { get; set; }
        public int Serial { get; set; }
        public string Description { get; set; }
    }
}
