using SaracliKend.Domain.Common.Contracts;

namespace SaracliKend.Domain.Entities;

public class School : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;
}
