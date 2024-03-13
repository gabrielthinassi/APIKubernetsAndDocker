namespace APIKubernetsAndDocker.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.UtcNow;
    }
}
