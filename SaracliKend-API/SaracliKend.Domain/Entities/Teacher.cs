using SaracliKend.Domain.Common.Contracts;
using SaracliKend.Domain.Enums;

namespace SaracliKend.Domain.Entities;

public class Teacher : IPerson
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public PersonType Type { get; set; }

    public School School { get; set; } = new School();

    public int SchoolId { get; set; }
}
