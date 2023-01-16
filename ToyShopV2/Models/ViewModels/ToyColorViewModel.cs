using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToyShopV2.Models.ViewModels
{
    public class ToyColorViewModel
    {
        public string SelectedColor { get; set; }
        public List<SelectListItem> ColorsAddSelectList { get; set; }
    }
}
