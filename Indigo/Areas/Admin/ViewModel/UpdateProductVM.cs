using Microsoft.Identity.Client;

namespace Indigo.Areas.Admin.ViewModel
{
    public class UpdateProductVM
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public string ImageUrl { get; set; }
    }
}
