namespace SaracliKend.Application.Models
{
    public class NewsViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public string? Image { get; set; }
    }
}
