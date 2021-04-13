using System;
using System.ComponentModel;
using VacationManager.Web.Models.TimeOffViewModels;

namespace VacationManager.Web.Models
{
    public class TimeOffsEditVM : BaseTimeOffEditViewModel
    {
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        [DisplayName("Half day")]
        public bool IsHalfDay { get; set; }
    }
}