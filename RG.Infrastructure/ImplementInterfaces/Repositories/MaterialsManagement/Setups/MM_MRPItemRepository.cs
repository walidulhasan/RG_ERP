using Newtonsoft.Json;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.AttributesDTO;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.DBEntities.MaterialsManagement.Setup;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Snickler.EFCore;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Setups
{
    public class MM_MRPItemRepository : GenericRepository<MM_MRPItem>, IMM_MRPItemRepository
    {
        private readonly MaterialsManagementDBContext _dbCon;
        public MM_MRPItemRepository(MaterialsManagementDBContext dbCon):base(dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<IList<MM_MRPItem>> GetManyMRPItem(Expression<Func<MM_MRPItem, bool>> match, CancellationToken cancellationToken=default)
        {
            return await FindAllAsync(match, cancellationToken);
        }

        public async Task<MM_MRPItem> GetMRPItem(int Id, CancellationToken cancellationToken=default)
        {
            return await GetByIdAsync(Id, cancellationToken);
        }

        public async Task<Attributes> GetMRPItemAttributeSet(int MRPItemCode, CancellationToken cancellationToken=default)
        {
            Attributes rtnModel = new Attributes();
            List<ReadJsonSP> JsonSPResult = new List<ReadJsonSP>();
            try
            {
                await _dbCon.LoadStoredProc("ajt.usp_GetMRPItemAttributeSet")
                .WithSqlParam("MRPItemCode", MRPItemCode)
                .ExecuteStoredProcAsync((handler) =>
                {
                    JsonSPResult = handler.ReadToList<ReadJsonSP>() as List<ReadJsonSP>;
                });
                rtnModel = JsonConvert.DeserializeObject<Attributes>(JsonSPResult.FirstOrDefault().Result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rtnModel;
        }

        public async Task<MM_MRPItem> GetMRPItemById(Expression<Func<MM_MRPItem, bool>> match, CancellationToken cancellationToken=default)
        {
            return await FindAsync(match,cancellationToken);
        }
    }
}
