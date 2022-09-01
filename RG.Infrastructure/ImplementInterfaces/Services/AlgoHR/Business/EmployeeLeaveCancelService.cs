using AutoMapper;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.Application.ViewModel.AlgoHR.Business.EmployeeLeaveCancel;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class EmployeeLeaveCancelService : IEmployeeLeaveCancelService
    {
        private readonly IEmployeeLeaveCancelRepository _employeeLeaveCancelRepository;
        private readonly IMapper _mapper;

        public EmployeeLeaveCancelService(IEmployeeLeaveCancelRepository employeeLeaveCancelRepository, IMapper mapper)
        {
            _employeeLeaveCancelRepository = employeeLeaveCancelRepository;
            _mapper = mapper;
        }
        public async Task<RResult> Create(EmployeeLeaveCancelVM model, bool saveChange = true)
        {
            try
            {
                RResult result = new();
                var entity = _mapper.Map<EmployeeLeaveCancelVM, EmployeeLeaveCancel>(model);

                entity.IsActive = true;
                var obj = await _employeeLeaveCancelRepository.InsertAsync(entity, saveChange);
                if (obj != null)
                {
                    result.result = 1;
                    result.message = ReturnMessage.UpdateMessage;

                }
                else
                {
                    result.result = 0;
                    result.message = ReturnMessage.ErrorMessage;
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
