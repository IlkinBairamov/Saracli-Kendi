using SaracliKend.Domain.Entities;

namespace SaracliKend.Infrastructure.Utils
{
    public static class MapperHelper
    {
        public static string GetFullname(Person person)
        {
            return person != null ? person.Name + " " + person.Surname : "";
        }
    }
}
