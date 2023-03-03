namespace WebApp.Models.Entitites
{
    public class ShowcaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title_1 { get; set; } = null!;
        public string Title_2 { get; set; } = null!;
        public string ImageName { get; set; } = null!;
        public DateTime Published { get; set; } = DateTime.Now;
    }
}
