using MediatR;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Contracts.AlgoHR.Business.TrainingCalendars.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.ViewComponents
{
    public class TrainingCalendarViewComponent : ViewComponent
    {
        private readonly IMediator mediator;
        public TrainingCalendarViewComponent(IMediator _mediator)
        {
            mediator = _mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync(TrainingCalendarRM calendarVM)
        {
            calendarVM.YearWiseMonths = Enumerable.Range(1, 12).Select(i => new YearWiseMonth() { MonthNo = i, MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) }).ToList();
            return View("TrainingCalendarVC", calendarVM);
        }
    }
}
