using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Setup
{
    public interface ITbl_AttendanceStatusService
    {
        Task<List<SelectListItem>> DDLAttendanceStatus(CancellationToken cancellationToken = default);
    }
}
