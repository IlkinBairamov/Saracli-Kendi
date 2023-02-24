using SaracliKend.Domain.Common.Contracts;
using SaracliKend.Domain.Enums;

namespace SaracliKend.Domain.Entities;

public class Person : IPerson
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string? Image { get; set; }

    public string Description { get; set; } = string.Empty;

    public PersonType Type { get; set; }
}
