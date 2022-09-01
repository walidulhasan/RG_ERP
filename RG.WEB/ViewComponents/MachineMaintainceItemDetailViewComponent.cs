using MediatR;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Queries;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Queries.RequestResponseModel;
using RG.Application.ViewModel.FiniteScheduler.Business.MachineMaintenance;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace RG.WEB.ViewComponents
{
    public class MachineMaintainceItemDetailViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public MachineMaintainceItemDetailViewComponent(IMediator _mediator)
        {
            mediator = _mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync(MachineMaintainceItemDetailQM queryModel)
        {
            var returnData = new List<MonthlyMachineMaintainceItemsVCVM>();
            var data = await mediator.Send(new GetMachineMaintainceItemDetailInfoQuery { LocationID = queryModel.LocationID, MachineID = queryModel.MachineID, Month = queryModel.Month, Year = queryModel.Year });

            var machineGroups=data.Select(x=>new { 
            x.MachineGroupID,
            x.MachineGroup
            }).Distinct().ToList();

            foreach (var machineGroup in machineGroups)
            {
                var grpWiseDataList =new List<GroupWiseMonthlyMachineMaintainceItemsVM>();
                var locationWiseMachines = data.Where(x=>x.MachineGroupID== machineGroup.MachineGroupID).Select(x => new
                {
                    x.LocationID,
                    x.LocationName,
                    x.MachineID,
                    x.MachineName
                }).Distinct().ToList();
                
                var checkItems = data.Where(x => x.MachineGroupID == machineGroup.MachineGroupID)
                        .Select(r => new MachineCheckItems
                        {
                            ItemName = r.ItemName,
                            ItemNameShort=r.ItemNameShort,
                            SerialNo = r.SerialNo
                        }).Distinct().OrderBy(y => y.SerialNo).ToList();

                foreach (var itemLocationMachine in locationWiseMachines)
                {
                    

                    var rtnChkDates = data.Where(x => x.LocationID == itemLocationMachine.LocationID && x.MachineID == itemLocationMachine.MachineID)
                        .GroupBy(y => new { y.LastCheckDate, y.ScheduleDate })
                        .Select(r => new MonthlyMachineMaintainceCheckDates
                        {
                            CheckDate = r.Key.LastCheckDate,
                            ScheduleDate = r.Key.ScheduleDate,
                        }).ToList();

                    foreach (var dates in rtnChkDates)
                    {
                        var rtnItems = data.Where(x => x.LocationID == itemLocationMachine.LocationID && x.MachineID == itemLocationMachine.MachineID
                                                      && x.LastCheckDate == dates.CheckDate && x.ScheduleDate == dates.ScheduleDate)
                            .Select(r => new CheckDateWiseItems
                            {
                                ItemName = r.ItemName,
                                SerialNo = r.SerialNo,
                                MechanicalChecked = r.MechanicalChecked,
                                ElectricalChecked = r.ElectricalChecked
                            }).Distinct().OrderBy(y => y.SerialNo).ToList();

                        dates.CheckDateWiseItems = rtnItems;
                    }

                    var rtnGrpWiseData = new GroupWiseMonthlyMachineMaintainceItemsVM()
                    {
                        LocationID = itemLocationMachine.LocationID,
                        LocationName = itemLocationMachine.LocationName,
                        MachineID = itemLocationMachine.MachineID,
                        MachineName = itemLocationMachine.MachineName,
                       
                        MonthlyMachineMaintainceCheckDates = rtnChkDates
                    };
                    grpWiseDataList.Add(rtnGrpWiseData);
                }
                var rtnData = new MonthlyMachineMaintainceItemsVCVM()
                {
                    MachineGroupID = machineGroup.MachineGroupID,
                    MachineGroup = machineGroup.MachineGroup,
                    MachineCheckItems = checkItems,
                    GroupWiseMonthlyMachineMaintainceItems = grpWiseDataList
                };

                returnData.Add(rtnData);
            }
            

            
            return View("MachineMaintainceItemDetailVC", returnData);
        }
    }
}
