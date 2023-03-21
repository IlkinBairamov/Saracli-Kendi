using SaracliKend.Domain.Common.Contracts;

namespace SaracliKend.Domain.Entities;

public class Legend : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
