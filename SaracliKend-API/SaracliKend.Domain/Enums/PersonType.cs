using System.ComponentModel;

namespace SaracliKend.Domain.Enums;

public enum PersonType
{
    [Description("Görkemli Şəxsiyyətlər")]
    Outstanding,
    [Description("Tanınmışlar")]
    Famous,
    [Description("Ziyalılar")]
    Intelligent,
    [Description("Veteranlar")]
    Veteran,
    [Description("Şəhidlər")]
    Martyr,
    [Description("Qaziler")]
    Ghazi,
    [Description("Müəllimlər")]
    Teacher,
    [Description("Yazar")]
    Writer
}
