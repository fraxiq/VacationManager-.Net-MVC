using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationManager.Data.TimeOff
{
    public class BaseTimeOff
    {
        [Key]
        public int id { get; set; }
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual bool IsHalfDay { get; set; }

        public bool IsApproved { get; set; }

        public int RequestorId { get; set; }
        public virtual ApplicationUser Requestor { get; set; }
    }
}
