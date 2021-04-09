using System;
using System.Collections.Generic;
using System.Text;

namespace VacationManager.Data.TimeOff
{
    class TemplateTimeOff
    {
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual bool IsHalfDay { get; set; }

        public bool IsApproved { get; set; }

        public virtual ApplicationUser Requestor { get; set; }
    }
}
