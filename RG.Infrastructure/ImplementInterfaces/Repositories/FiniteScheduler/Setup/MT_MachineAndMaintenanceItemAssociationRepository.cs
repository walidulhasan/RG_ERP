using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.MT_MachineAndMaintenanceItemAssociations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineAndMaintenanceItemAssociations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineAndMaintenanceItemAssociations.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.DBEntities.FiniteScheduler.Setup;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Setup
{
    public class MT_MachineAndMaintenanceItemAssociationRepository : GenericRepository<MT_MachineAndMaintenanceItemAssociation>, IMT_MachineAndMaintenanceItemAssociationRepository
    {
        private FiniteSchedulerDBContext dbCon;

        public MT_MachineAndMaintenanceItemAssociationRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<List<MachineWiseMaintenanceItemDetailResponseModel>> GetMachineWiseMaintenanceItemDetailList(int machineID,int masterID, CancellationToken cancellationToken)
        {
            try
            {
                var data = from mi in dbCon.MT_MaintenanceItem_Setup
                           join mi_associated in dbCon.MT_MachineAndMaintenanceItemAssociation
                                on new { MachineID = machineID, ItemID = mi.ID, IsRemoved = false, IsActive = true }
                                equals new { mi_associated.MachineID, ItemID = mi_associated.MaintenanceItemID, mi_associated.IsRemoved, mi_associated.IsActive }
                           join cm in dbCon.MT_MachineAndMaintenanceCheckListMaster
                                on new { mi_associated.MachineID, MasterID = masterID, IsRemoved = false, IsActive = true } equals new { cm.MachineID, MasterID = cm.ID,cm.IsRemoved,cm.IsActive }
                                into cmlj
                           from _cmlj in cmlj.DefaultIfEmpty()
                           join cd in dbCon.MT_MachineAndMaintenanceCheckListDetails
                                on new { MasterID = _cmlj.ID, mi_associated.AssociationID, IsRemoved = false, IsActive = true } equals new { cd.MasterID, cd.AssociationID,cd.IsRemoved,cd.IsActive }
                                into cdlj
                           from _cdlj in cdlj.DefaultIfEmpty()
                           select new MachineWiseMaintenanceItemDetailResponseModel
                           {
                               MasterID = masterID,
                               AssociationID = mi_associated.AssociationID,
                               MaintenanceItemID = mi.ID,
                               ItemName = mi.ItemName,
                               MachineID = machineID,
                               ElectricalChecked=_cdlj==null?false:_cdlj.ElectricalChecked.Value,
                               ElectricalComments = _cdlj == null ? "" : _cdlj.ElectricalComments==null?"" : _cdlj.ElectricalComments,
                               MechanicalChecked=_cdlj==null?false:_cdlj.MechanicalChecked.Value,
                               MechanicalComments = _cdlj == null ? "" : _cdlj.MechanicalComments==null?"": _cdlj.MechanicalComments,
                               ItemCategoryID = mi.ItemCategoryID,
                               MasterDetailID = _cdlj == null ? 0 : _cdlj.ID
                           };

               var _data= await data.ToListAsync(cancellationToken);
                return _data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public async Task<List<MachineWiseMaintenanceItemResponseModel>> GetMachineWiseMaintenanceItemList(int machineID, CancellationToken cancellationToken)
        {
            var data = from mi in dbCon.MT_MaintenanceItem_Setup
                       join mi_associated in dbCon.MT_MachineAndMaintenanceItemAssociation
                       on new { MachineID = machineID, ItemID = mi.ID, IsRemoved = false, IsActive = true }
                       equals new { MachineID = mi_associated.MachineID, ItemID = mi_associated.MaintenanceItemID, IsRemoved = mi_associated.IsRemoved, IsActive = mi_associated.IsActive }
                       into Association from machineAssociation in Association.DefaultIfEmpty()

                       select new MachineWiseMaintenanceItemResponseModel
                       {
                           AssociationID = machineAssociation == null ? 0 : machineAssociation.AssociationID,
                           MaintenanceItemID = mi.ID,
                           ItemName = mi.ItemName,
                           MachineID = machineID
                       };

            return await data.ToListAsync(cancellationToken);
        }

        public async Task<RResult> RemoveMachineMaintainceAssociation(List<UpdateAssociationDTM> models)
        {
            var rResult = new RResult();

            var associationID = models.Select(b => b.AssociationID).ToList();
            var machineID = models.First().MachineID;

            var dbData = await dbCon.MT_MachineAndMaintenanceItemAssociation
                .Where(b => b.MachineID == machineID && b.IsRemoved == false && b.IsActive == true && associationID.Contains(b.AssociationID)).ToListAsync();
            dbData.ForEach(b => { b.IsRemoved = true;b.IsActive = false;});
            await dbCon.SaveChangesAsync();
            rResult.result = 1;
            rResult.message = ReturnMessage.DeleteMessage;

            return rResult;
        }

        public async Task<RResult> SaveMachineAndMaintenanceItemAssociation(List<MT_MachineAndMaintenanceItemAssociation> entities, bool saveChange)
        {
            var rResult = new RResult();

            int? serialNo = 0;
            serialNo = (await dbCon.MT_MachineAndMaintenanceItemAssociation.ToListAsync()).Max(m => m.SerialNo);

            if (serialNo != null)
            {
                serialNo++;
            }
            else
            {
                serialNo = 1;
            }
            entities.ForEach(x => { x.IsActive = true; x.IsRemoved = false; x.CreatedDate = DateTime.Now; x.SerialNo = serialNo++; });

            await InsertAsync(entities, saveChange);
            rResult.result = 1;
            rResult.message = ReturnMessage.InsertMessage;

            return rResult;
        }
    }
}
