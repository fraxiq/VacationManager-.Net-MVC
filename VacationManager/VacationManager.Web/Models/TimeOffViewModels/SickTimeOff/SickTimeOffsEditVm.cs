using Microsoft.AspNetCore.Http;

namespace VacationManager.Web.Models.TimeOffViewModels.SickTimeOff
{
    public class SickTimeOffsEditVM : TimeOffsEditVM
    {
        public string AttachmentPath { get; set; }
        public IFormFile Attachment { get; set; }
    }
}