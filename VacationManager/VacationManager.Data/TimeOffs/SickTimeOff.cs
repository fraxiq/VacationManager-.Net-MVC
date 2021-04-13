using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationManager.Data.TimeOff
{
    public class SickTimeOff : BaseTimeOff
    {
        public string AttachmentPath { get; set; }
        public string Attachment { get; set; }

        [NotMapped]
        public override bool IsHalfDay { get; set; }
    }
}
