using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Indigo.Models
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
    }
}
    