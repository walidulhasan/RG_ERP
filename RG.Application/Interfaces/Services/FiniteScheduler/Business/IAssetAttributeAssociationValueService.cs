using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.FiniteScheduler.Business
{
    public interface IAssetAttributeAssociationValueService
    {
        Task<List<string>> AttributeValueAutoComplete(int assetSubTypeID, int attributeID,string predict, CancellationToken cancellationToken);
    }
}
