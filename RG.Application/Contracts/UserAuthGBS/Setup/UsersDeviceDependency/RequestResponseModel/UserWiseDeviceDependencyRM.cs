using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.UserAuthGBS.Setup.UsersDeviceDependency.RequestResponseModel
{
    public class UserWiseDeviceDependencyRM
    {
        public int UserID { get; set; }
        public int? DeviceDependencyTypeID { get; set; }
        public string DeviceIdentity { get; set; }
        public string DeviceType { get; set; }
    }
}
