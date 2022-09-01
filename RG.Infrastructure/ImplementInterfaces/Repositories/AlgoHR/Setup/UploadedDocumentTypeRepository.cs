using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Setup
{
    public class UploadedDocumentTypeRepository : GenericRepository<UploadedDocumentType>, IUploadedDocumentTypeRepository
    {
        private readonly AlgoHRDBContext _dbCon;
        public UploadedDocumentTypeRepository(AlgoHRDBContext context)
            : base(context)
        {
            _dbCon = context;
        }
        public async Task<List<SelectListItem>> DDLUploadedDocumentType(string modeuleName, CancellationToken cancellationToken = default)
        {
            var data = await _dbCon.UploadedDocumentType.Where(x => x.ModuleName == modeuleName)
                        .Select(row => new SelectListItem()
                        {
                            Text = row.DocumentType,
                            Value = row.DocumentTypeID.ToString()
                        }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
