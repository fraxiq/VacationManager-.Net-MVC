using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationManager.Data.Data;
using VacationManager.Data.TimeOff;

namespace VacationManager.Web.Controllers
{
    public class UnpaidTimeOffController : TimeOffController<UnpaidTimeOff>
    {
        public UnpaidTimeOffController(VacationDbContext context) : base(context, context.UnpaidTimeOffs)
        {

        }
    }
}
