using RG.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public interface ITrainingDocumentsService
    {
        Task<RResult> DeleteDocument(int id);
    }
}
