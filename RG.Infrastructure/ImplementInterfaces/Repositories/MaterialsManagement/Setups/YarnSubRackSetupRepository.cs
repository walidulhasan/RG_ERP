using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.Application.ViewModel.MaterialsManagement.Setup;
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
    public class YarnSubRackSetupRepository : GenericRepository<YarnSubRackSetup>, IYarnSubRackSetupRepository
    {
        private readonly MaterialsManagementDBContext _dbCon;
        private readonly IMapper _mapper;

        public YarnSubRackSetupRepository(MaterialsManagementDBContext dbCon, IMapper mapper) : base(dbCon)
        {
            _dbCon = dbCon;
            _mapper = mapper;
        }

        public async Task<List<SelectListItem>> DDLRackWiseSubRack(int rackID, bool withStorageLimit = false, CancellationToken cancellationToken=default)
        {
            var data = await _dbCon.YarnSubRackSetup.Where(x => x.RackID == rackID && x.IsActive == true && x.IsRemoved == false)
                .OrderBy(b => b.SubRackSerial)
                .Select(x => new SelectListItem
                {
                    Text = withStorageLimit ? $"{x.SubRackName} ({x.StorageLimit})" : x.SubRackName,
                    Value = x.SubRackID.ToString()
                }).ToListAsync(cancellationToken);
            return data;
        }
        public async Task<List<DropDownItem>> CustomDDLRackWiseSubRack(int rackID, bool withStorageLimit = false, CancellationToken cancellationToken = default)
        {
            var data = await _dbCon.YarnSubRackSetup.Where(x => x.RackID == rackID && x.IsActive == true && x.IsRemoved == false)
                .OrderBy(b=>b.SubRackSerial)
                .Select(x => new DropDownItem
                {
                    Text = withStorageLimit ? $"{x.SubRackName} ({x.StorageLimit} kg)" : x.SubRackName,
                    Value = x.SubRackID.ToString(),
                    Custom1 = $"{x.StorageLimit}"
                }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<YarnSubRackVM>> SubRackEdit(int rackID, CancellationToken cancellationToken)
        {
            var model = await (from ysr in _dbCon.YarnSubRackSetup
                               where ysr.RackID == rackID && ysr.IsActive == true && ysr.IsRemoved == false
                               select new YarnSubRackVM
                               {
                                   SubRackID = ysr.SubRackID,
                                   RackID = ysr.RackID,
                                   SubRackName = ysr.SubRackName,
                                   SubRackShortName = ysr.SubRackShortName,
                                   SubRackSerial = ysr.SubRackSerial,
                                   SubRackRowSerial = ysr.SubRackRowSerial,
                                   SubRackColumnSerial = ysr.SubRackColumnSerial,
                                   SubRackDescription = ysr.SubRackDescription,
                                   StorageLimit = ysr.StorageLimit,
                               }).ToListAsync(cancellationToken);
            return model;
        }
    }
}
