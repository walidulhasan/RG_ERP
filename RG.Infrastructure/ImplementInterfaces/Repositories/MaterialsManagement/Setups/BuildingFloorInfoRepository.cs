using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingFloorInfos.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.DBEntities.MaterialsManagement.Setup;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Setups
{
    public class BuildingFloorInfoRepository : GenericRepository<BuildingFloorInfo>, IBuildingFloorInfoRepository
    {
        private readonly MaterialsManagementDBContext _dbCon;
        private readonly ICurrentUserService _currentUserService;

        public BuildingFloorInfoRepository(MaterialsManagementDBContext dbCon, ICurrentUserService currentUserService) :base(dbCon)
        {
            _dbCon = dbCon;
            _currentUserService = currentUserService;
        }

        public async Task<List<SelectListItem>> DDLBuildingWiseBuildingFloor(int Building, int FloorType, string predict, CancellationToken cancellationToken)
        {
            var query=from bfi in _dbCon.BuildingFloorInfo
                      where (Building==0 || bfi.BuildingID==Building) 
                      && bfi.FloorTypeID==FloorType //&& bfi.CompanyID== _currentUserService.CompanyID
                      select new SelectListItem
                      {
                          Text = bfi.FloorName,
                          Value = bfi.BuildingFloorID.ToString()
                      };

            if (predict != null)
            {
                query = query.Where(x => x.Text.Contains(predict));
            }
            var data= await query.Distinct().ToListAsync(cancellationToken);
            return data;
        }

        public IQueryable<BuildingFloorInfoRM> GetListOfBuildingFloorInfo()
        {
            var queryList = from bfi in _dbCon.BuildingFloorInfo
                            join bt in _dbCon.BuildingType on bfi.BuildingID equals bt.ID
                            join ft in _dbCon.FloorType on bfi.FloorTypeID equals ft.FloorTypeID
                            where bfi.IsActive==true && bfi.IsRemoved==false
                            select new BuildingFloorInfoRM()
                            {
                                BuildingFloorID=bfi.BuildingFloorID,
                                BuildingTypeName = bt.BuildingTypeName,
                                ID=bt.ID,
                                BuildingID=bfi.BuildingID,
                                FloorDescription =bfi.FloorDescription,
                                FloorName=bfi.FloorName,
                                FloorSerial=bfi.FloorSerial,
                                FloorShortName = bfi.FloorShortName,
                                FloorType=ft.FloorTypeName,
                                FloorTypeID=bfi.FloorTypeID
                            };
            return queryList;
        }
    }
}
