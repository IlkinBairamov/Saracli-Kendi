using SaracliKend.Domain.Common.Contracts;

namespace SaracliKend.Domain.Entities;

public class SliderImage : IEntity
{
    public int Id { get; set; }

    public string Path { get; set; } = string.Empty;
}
