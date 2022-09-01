using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetAssignedTypes.Queries.RequestResponseModel
{
    public class AssetAssignedTypeRM
    {
        public int AssignedTypeNameID { get; set; }
        public string AssignedTypeName { get; set; }
        public string AssignedTypeCode { get; set; }
    }
}
