using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Commands.DataTransferModel;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Queries.RequestResponseModel;
using RG.Application.IdentityEntities;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Setups
{
    public class IC_UserDepartmentSetupService : IIC_UserDepartmentSetupService
    {
        private readonly IIC_UserDepartmentSetupRepository iC_UserDepartmentSetupRepository;
        private readonly IIC_DepartmentRepository iC_DepartmentRepository;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public IC_UserDepartmentSetupService(IIC_UserDepartmentSetupRepository _iC_UserDepartmentSetupRepository,
            IIC_DepartmentRepository _iC_DepartmentRepository, IMapper _mapper, UserManager<ApplicationUser> _userManager)
        {
            iC_UserDepartmentSetupRepository = _iC_UserDepartmentSetupRepository;
            iC_DepartmentRepository = _iC_DepartmentRepository;
            mapper = _mapper;
            userManager = _userManager;
        }
        public async Task<List<UserWiseDepartmentRM>> GetUserWiseDepartmentByUserID(int userID, CancellationToken cancellationToken)
        {
            try
            {
                var algoUserID = 0;
                var user = await userManager.FindByIdAsync(userID.ToString());
                if (user != null)
                    algoUserID = user.SourceUserID ?? 0;


                var dList = await iC_DepartmentRepository.GetAllData();
                var userdlist = await iC_UserDepartmentSetupRepository
                                    .FindAllAsync(p => p.IsRemoved == false 
                                             && (p.UserId == algoUserID || p.AuthUserId == user.Id), cancellationToken);

                //var assaignDepartment = (from d in dList
                //                         join asnd in userdlist on d.ID equals asnd.DepartmentId
                //                         //where asnd.UserId == algoUserID && asnd.AuthUserId== userID && asnd.IsRemoved == false
                //                         select new UserAssaignDepartmentRM()
                //                         {
                //                             DepartmentName = d.Name,
                //                             DepartmentId = asnd.DepartmentId,
                //                             UserID = asnd.UserId.Value,
                //                             IsRemove = asnd.IsRemoved,
                //                             ID = d.ID,
                //                             UserDepartmentSetupID = asnd.Id
                //                         }).ToList();

                var finalList = new List<UserWiseDepartmentRM>();
                if (userdlist.Count() > 0)
                {
                    var list = (from dd in dList
                                join ass in userdlist on dd.ID equals ass.DepartmentId into tbluserDepartment
                                from assd in tbluserDepartment.DefaultIfEmpty()
                                select new UserWiseDepartmentRM()
                                {
                                    ID = dd.ID,
                                    DepartmentId = (assd != null && assd.DepartmentId != null) ? assd.DepartmentId : 0,
                                    DepartmentName = dd.Name,
                                    // IsRemove = ass.IsRemove,
                                    UserID = assd != null ? assd.UserId??0:0,
                                    AuthUserId = assd != null ? assd.AuthUserId??0:0,
                                    UserDepartmentSetupID = assd != null ? assd.Id : 0
                                }).ToList();
                    finalList = list;

                }
                else
                {
                    foreach (var item in dList)
                    {
                        var obj = new UserWiseDepartmentRM();
                        obj.ID = item.ID;
                        obj.DepartmentName = item.Name;
                        finalList.Add(obj);
                    }
                }

                return finalList;
            }
            catch (Exception e)
            {

                throw new Exception("You are not Associated");
            }
        }

        public async Task<RResult> SaveUserWiseDepartmentAssaign(List<IC_UserDepartmentSetupDTM> list, CancellationToken cancellationToken)
        {
            var algoUserID = 0;
            var user = await userManager.FindByIdAsync(list[0].AuthUserId.ToString());
            if (user != null)
                algoUserID = user.SourceUserID ?? 0; ;

            var mainObj = mapper.Map<List<IC_UserDepartmentSetupDTM>, List<IC_UserDepartmentSetup>>(list);
            mainObj.ToList().ForEach(b => { b.UserId = algoUserID; b.CreateDate = DateTime.Now; b.IsRemoved = false; });
            return await iC_UserDepartmentSetupRepository.SaveUserWiseDepartmentAssaign(mainObj, cancellationToken);
        }

        public async Task<RResult> UserDepartmentRemove(List<IC_UserDepartmentSetupDTM> list, CancellationToken cancellationToken)
        {
            return await iC_UserDepartmentSetupRepository.UserDepartmentRemove(list, cancellationToken);
        }
    }
}
