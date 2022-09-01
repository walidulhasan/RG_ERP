using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.EMS.Business.ShipmentReport
{
    public class PaymentNotReceivedWithinExpectedDateVM
    {
        public string DateUpto { get; set; }=DateTime.Now.ToString("dd-MMM-yyyy");
    }
}
