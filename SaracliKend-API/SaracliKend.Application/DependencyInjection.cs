using Microsoft.Extensions.DependencyInjection;
using SaracliKend.Application.Services;
using SaracliKend.Application.Services.Contracts;

namespace SaracliKend.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<ISchoolService, SchoolService>();
        services.AddScoped<ISliderImageService, SliderImageService>();
        services.AddScoped<ILegendService, LegendService>();
        services.AddScoped<IPoetryService, PoetryService>();
        services.AddScoped<IFunnyStoryService, FunnyStoryService>();
        services.AddScoped<IInformationService, InformationService>();
        services.AddScoped<INewsService, NewsService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IFooterService, FooterService>();

        return services;
    }
}
