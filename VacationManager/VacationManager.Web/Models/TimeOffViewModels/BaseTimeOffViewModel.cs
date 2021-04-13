using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationManager.Data;

namespace VacationManager.Web.Models.TimeOffViewModels
{
    public class BaseTimeOffViewModel
    {
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsHalfDay { get; set; }

        public bool IsApproved { get; set; }

        public int RequestorId { get; set; }
        public ApplicationUser Requestor { get; set; }
    }
}
