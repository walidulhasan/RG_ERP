using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.AlgoHR.Setup.SystemNotice
{
    public class SystemNoticeVM
    {
        public SystemNoticeVM()
        {
            CustomCusting = new List<SystemNoticeCustomCustingVM>();
        }
        public int NoticeID { get; set; }
        public string NoticeTitle { get; set; }
        public string NoticeDescription { get; set; }
        public string ValidDateFrom { get; set; }
        public string ValidTimeFrom { get; set; }
        public string ValidDateTo { get; set; }
        public string ValidTimeTo { get; set; }
        public bool ShowDetail { get; set; }
        public bool MulticastNotice { get; set; }
        public List<SystemNoticeCustomCustingVM> CustomCusting { get; set; }
    }
}
