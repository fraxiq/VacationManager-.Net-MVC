using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VacationManager.Data.TimeOff
{
    class SickTimeOff : TemplateTimeOff
    {
        public string AttachmentPath { get; set; }

        [NotMapped]
        public override bool IsHalfDay { get; set; }
    }
}
