using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationManager.Data.Data;
using VacationManager.Data.TimeOff;

namespace VacationManager.Web.Controllers
{
    public class PaidTimeOffController : TimeOffController<PaidTimeOff>
    {
        public PaidTimeOffController(VacationDbContext context): base (context, context.PaidTimeOffs)
        {

        }

    }
}
