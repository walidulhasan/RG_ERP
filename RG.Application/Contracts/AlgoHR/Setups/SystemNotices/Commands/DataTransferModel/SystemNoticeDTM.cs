using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;

namespace RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Commands.DataTransferModel
{
    public class SystemNoticeDTM:IMapFrom<SystemNotice>
    {
        public int NoticeID { get; set; }
        public string NoticeTitle { get; set; }
        public string NoticeDescription { get; set; }
        public DateTime ValidDateFrom { get; set; }
        public string ValidTimeFrom { get; set; }
        public DateTime ValidDateTo { get; set; }
        public string ValidTimeTo { get; set; }
        public bool ShowDetail { get; set; }
        public List<SystemNoticeCustomCustingDTM> CustomCasting { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SystemNoticeDTM, SystemNotice>();
        }
    }
}
