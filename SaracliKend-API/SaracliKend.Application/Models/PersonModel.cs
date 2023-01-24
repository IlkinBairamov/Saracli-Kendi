using SaracliKend.Domain.Common.Contracts;
using SaracliKend.Domain.Enums;

namespace SaracliKend.Application.Models;

public class PersonModel : IPerson
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Image { get; set; }
    public string Description { get; set; }
    public PersonType Type { get; set; }
    public int Id { get; set; }
}
