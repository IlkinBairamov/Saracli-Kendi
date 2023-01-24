namespace SaracliKend.Application.Models;

public class FunnyStoryVM
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string? Writer { get; set; }

    public int PersonId { get; set; }
}
