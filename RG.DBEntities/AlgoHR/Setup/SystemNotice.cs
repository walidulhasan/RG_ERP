using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.AlgoHR.Setup
{
    public class SystemNotice : DefaultTableProperties
    {
        [Key]
        public int NoticeID { get; set; }
        public string NoticeTitle { get; set; }
        public string NoticeDescription { get; set; }
        public DateTime ValidDateFrom { get; set; }
        public DateTime ValidDateTo { get; set; }
        public bool ShowDetail { get; set; }
        public List<SystemNoticeCustomCusting> CustomCasting { get; set; }
    }
}
