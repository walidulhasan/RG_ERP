using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RG.Application.Contracts.Maxco.Buisness.Style.Queries.RequestResponseModel
{
    public class StyleRM : IMapFrom<RG.DBEntities.Maxco.Business.Style>
    {
        public long ID { get; set; }
        public string Description { get; set; }
        public int? GarmentID { get; set; }
        public int? Status { get; set; }
        public DateTime? SamplingDate { get; set; }
        public int? CapturingStatus { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? SeriesID { get; set; }
        public long? ParentStyleID { get; set; }
        public int? FabricCategoryID { get; set; }
        public long? ParentID { get; set; }
        public string OrderNo { get; set; }
        public int? CollectionID { get; set; }
        public int? UserID { get; set; }
        public int? ProcurementStatus { get; set; }
        public int IsLocked { get; set; }
        public int IsDummy { get; set; }
        public bool GrossStatus { get; set; }
        public DateTime? EstimatedDate { get; set; }
        public byte[]? FrontImage { get; set; }
        public byte[] BackImage { get; set; }
        public string ReferenceNo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<StyleRM, RG.DBEntities.Maxco.Business.Style>().ReverseMap();
        }
    }
}

