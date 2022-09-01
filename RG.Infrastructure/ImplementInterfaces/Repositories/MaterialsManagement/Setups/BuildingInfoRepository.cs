using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.CommonInterfaces;
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
    public class BuildingInfoRepository : GenericRepository<BuildingInfo>, IBuildingInfoRepository
    {
        private readonly MaterialsManagementDBContext _dbCon;
        private readonly ICurrentUserService _currentUserService;

        public BuildingInfoRepository(MaterialsManagementDBContext dbCon, ICurrentUserService currentUserService) : base(dbCon)
        {
            _dbCon = dbCon;
            _currentUserService = currentUserService;
        }

        public async Task<List<SelectListItem>> DDLFloorTypeWiseBuilding(int FloorType, string predict, CancellationToken cancellationToken)
        {
            try
            {
                var query = from bi in _dbCon.BuildingInfo
                            join bfi in _dbCon.BuildingFloorInfo on bi.BuildingID equals bfi.BuildingID
                            where bfi.FloorTypeID == FloorType //&& bfi.CompanyID== _currentUserService.CompanyID
                            select new SelectListItem
                            {
                                Text = bi.BuildingName,
                                Value = bi.BuildingID.ToString()
                            };

                if (predict != null)
                {
                    query = query.Where(x => x.Text.Contains(predict));
                }
                var a = query.ToQueryString();
                return await query.Distinct().ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<BuildingInfo> BuildingFloorWiseBuildingInfo(int budlingFloorID, CancellationToken cancellationToken)
        {
            try
            {
                var data = await (from bfi in _dbCon.BuildingFloorInfo
                                  join bi in _dbCon.BuildingInfo on bfi.BuildingID equals bi.BuildingID
                                  where bfi.BuildingFloorID == budlingFloorID
                                  select bi).FirstAsync(cancellationToken);
                return data;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<SelectListItem>> BuildingTypeWiseBuildingInfo(int ID, string predict, CancellationToken cancellationToken)
        {
            try
            {
                var query = from bi in _dbCon.BuildingInfo
                            join bfi in _dbCon.BuildingType on bi.BuildingTypeID equals bfi.ID
                            where bi.BuildingTypeID == ID
                            select new SelectListItem
                            {
                                Text = bi.BuildingName,
                                Value = bi.BuildingID.ToString()
                            };

                if (predict != null)
                {
                    query = query.Where(x => x.Text.Contains(predict));
                }
                return await query.Distinct().ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
