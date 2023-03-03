namespace WebApp.Models.Entitites
{
    public class TagEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TagName { get; set; } = null!;

        public virtual ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();

    }
}
