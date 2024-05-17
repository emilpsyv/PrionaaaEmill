
namespace ProniaEmil.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; }

        public static implicit operator Category(int v)
        {
            throw new NotImplementedException();
        }
    }
}
