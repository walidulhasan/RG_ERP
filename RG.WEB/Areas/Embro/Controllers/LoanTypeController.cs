using MediatR;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Common.Models;
using RG.Application.Contracts.Embro.Setups.LoanTypes.Commands.Create;
using RG.Application.Contracts.Embro.Setups.LoanTypes.Commands.Update;
using RG.Application.Contracts.Embro.Setups.LoanTypes.Queries;
using RG.Application.Interfaces.Services.Embro.Setups;
using RG.Application.ViewModel.Embro.Setup.LoanType;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Embro.Controllers
{
    [Area("Embro")]
    [Route("Embro/[controller]/[action]")]
    public class LoanTypeController : BaseController
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LoanTypeCreateVM model)
        {
            RResult rResult = new RResult();
            //if (ModelState.IsValid)
            //{
                rResult = await Mediator.Send(new LoanTypeCreateCommand { loanType = model });
            //}

            return Json(rResult);
        }


        [HttpGet]
        public async Task<IActionResult> GetListOfLoanType(DataSourceLoadOptions loadOptions)
        {
            loadOptions.PrimaryKey = new[] { "ID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var data = await Mediator.Send(new GetListOfLoanTypeQuery { LoadOptions = loadOptions });
            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(LoanTypeCreateVM model)
        {
            RResult result = new();
            result = await Mediator.Send(new LoanTypeUpdateCommand { model = model });
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {

            RResult result = new();
            result = await Mediator.Send(new LoanTypeRemoveCommand { id = id });
            return Json(result);
        }
    }

}
