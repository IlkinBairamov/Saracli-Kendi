using SaracliKend.Domain.Enums;

namespace SaracliKend.Domain.Common.Contracts;

public interface IPerson : IEntity
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string Image { get; set; }

    public string Description { get; set; }

    public PersonType Type { get; set; }
}
