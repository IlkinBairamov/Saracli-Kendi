using SaracliKend.Domain.Enums;

namespace SaracliKend.Application.Models;

public class PersonListModel
{
    public List<PersonModel> People { get; set; }

    public PersonType Type { get; set; }
}
