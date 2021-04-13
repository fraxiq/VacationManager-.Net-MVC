using System;
using VacationManager.Web.Models.TimeOffViewModels.Base;

namespace VacationManager.Web.Models
{
    public class TimeOffsVM : BaseVM
    {
        public DateTime CreatedOn { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public bool IsApproved { get; set; }

        public bool IsHalfDay { get; set; }
    }
}