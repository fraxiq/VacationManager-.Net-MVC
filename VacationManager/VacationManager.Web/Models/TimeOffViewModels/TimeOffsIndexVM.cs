using System.Collections.Generic;
using VacationManager.Web.Models.Filters;
using VacationManager.Web.Models.TimeOffViewModels.PaidTimeOffs;
using VacationManager.Web.Models.TimeOffViewModels.SickTimeOff;
using VacationManager.Web.Models.TimeOffViewModels.UnpaidTimeOffs;

namespace VacationManager.Web.Models
{
    public class TimeOffsIndexVM
    {
        public TimeOffsFilterVM PaidTimeOffsFilter { get; set; }

        public TimeOffsFilterVM UnpaidTimeOffsFilter { get; set; }

        public TimeOffsFilterVM SickTimeOffsFilter { get; set; }

        public PagerVM PaidTimeOffsPager { get; set; }

        public PagerVM UnpaidTimeOffsPager { get; set; }

        public PagerVM SickTimeOffsPager { get; set; }

        public List<PaidTimeOffsVM> PaidTimeOffs { get; set; }

        public List<UnpaidTimeOffsVM> UnpaidTimeOffs { get; set; }

        public List<SickTimeOffsVM> SickTimeOffs { get; set; }
    }
}