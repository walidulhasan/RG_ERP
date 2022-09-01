using Microsoft.AspNetCore.Mvc.Rendering;

namespace RG.Application.Common.Models
{
    public class DropDownItem
    {
        public bool Selected { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public string Custom1 { get; set; }
        public string Custom2 { get; set; }
        public string Custom3 { get; set; }
        public string Custom4 { get; set; }
        public SelectListGroup Group { get; set; }
    }
}
