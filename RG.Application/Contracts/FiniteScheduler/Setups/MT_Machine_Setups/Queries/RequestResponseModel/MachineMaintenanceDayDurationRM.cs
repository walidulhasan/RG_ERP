using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Queries.RequestResponseModel
{
  public  class MachineMaintenanceDayDurationRM
    {
        public int MachineID { get; set; }
        public int MachineName { get; set; }
        public int MinMaintainceDurationDays { get; set; }

    }
}
