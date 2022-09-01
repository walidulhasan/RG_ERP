using RG.Application.Contracts.MaterialsManagement.AttributesDTO;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Setups
{
    public class MM_MRPItemService : IMM_MRPItemService
    {
        private readonly IMM_MRPItemRepository _mm_MRPItemRepository;
        public MM_MRPItemService(IMM_MRPItemRepository mm_MRPItemRepository)
        {
            _mm_MRPItemRepository = mm_MRPItemRepository;
        }
        public async Task<IList<MM_MRPItem>> GetManyMRPItem(Expression<Func<MM_MRPItem, bool>> match, CancellationToken cancellationToken = default)
        {
            return await _mm_MRPItemRepository.GetManyMRPItem(match,cancellationToken);
        }

        public async Task<Attributes> GetMRPItemAttributeSet(int MRPItemCode, CancellationToken cancellationToken = default)
        {
            return await _mm_MRPItemRepository.GetMRPItemAttributeSet(MRPItemCode, cancellationToken);
        }

        public async Task<MM_MRPItem> GetMRPItemById(Expression<Func<MM_MRPItem, bool>> match, CancellationToken cancellationToken = default)
        {
            return await _mm_MRPItemRepository.GetMRPItemById(match, cancellationToken);
        }
    }
}
