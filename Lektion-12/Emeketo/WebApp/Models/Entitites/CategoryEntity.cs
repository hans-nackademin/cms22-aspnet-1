namespace WebApp.Models.Entitites
{
    public class CategoryEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();

    }
}
