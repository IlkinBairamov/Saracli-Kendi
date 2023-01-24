using SaracliKend.Domain.Entities;

namespace SaracliKend.Infrastructure.Utils
{
    public static class MapperHelper
    {
        public static string GetFullname(Person person)
        {
            var fullName = person.Name + " " + person.Surname;
            return fullName;
        }
    }
}
