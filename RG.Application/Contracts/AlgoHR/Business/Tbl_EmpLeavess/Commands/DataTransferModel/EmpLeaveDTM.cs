using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;

namespace RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Commands.DataTransferModel
{
    public class EmpLeaveDTM : IMapFrom<Tbl_EmpLeaves>
    {
        public long Leave_Emp { get; set; }
        public string Leave_EmpCD { get; set; }
        public int Leave_ID { get; set; }
        public DateTime Leave_From { get; set; }
        public DateTime Leave_To { get; set; }
        public string Leave_Reason { get; set; }
        public string Leave_Address { get; set; }
        public DateTime? Complimentary_LeaveDate { get; set; }
        public List<ImageUpload> UploadedImages { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpLeaveDTM, Tbl_EmpLeaves>().ReverseMap();
        }
    }
    public class ImageUpload
    {
        public string ImageType { get; set; }
        public int DocumentTypeID { get; set; }
        public string ImageBase64String { get; set; }
    }
}
