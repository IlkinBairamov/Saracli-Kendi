namespace SaracliKend.Application.Models;

public class HomeViewModel
{
    public List<SliderViewModel> SliderImages { get; set; }

    public List<PersonModel> Martyrs { get; set; }

    public List<PersonModel> Ghazis { get; set; }

    public List<NewsViewModel> News { get; set; }
}
