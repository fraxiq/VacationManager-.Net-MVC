﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VacationManager.Web.Models.Filters
{
    public class TimeOffsFilterVM
    {
        [DisplayName("Created after")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedAfter { get; set; }
    }
}