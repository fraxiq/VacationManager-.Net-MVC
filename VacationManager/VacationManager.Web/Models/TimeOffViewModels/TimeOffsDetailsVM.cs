using System;
using VacationManager.Web.Models.TimeOffViewModels.Base;

namespace VacationManager.Web.Models
{
    public class TimeOffsDetailsVM : BaseDetailsVM
    {
        public DateTime LastChangedOn { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public bool IsApproved { get; set; }

        public bool IsHalfDay { get; set; }
    }
}