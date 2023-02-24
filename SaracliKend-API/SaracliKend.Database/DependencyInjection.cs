using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaracliKend.Core.Repositories;
using SaracliKend.Database.Context;
using SaracliKend.Database.Repositoires.EntityFrameworkCore;
using SaracliKend.Database.Repositories.EntityFrameworkCore;

namespace SaracliKend.Database;

public static class DependencyInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SaracliDbContext>(options =>
        {
            options.UseSqlServer(connectionString, builder =>
            {
                builder.MigrationsAssembly(typeof(SaracliDbContext).Assembly.FullName);
            });
        });

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPersonRepository, EFPersonRepository>();
        services.AddScoped<ISchoolRepository, EFSchoolRepository>();
        services.AddScoped<ISliderImageRepository, EFSliderImageRepository>();
        services.AddScoped<ILegendRepository, EFLegendRepository>();
        services.AddScoped<IPoetryRepository, EFPoetryRepository>();
        services.AddScoped<IFunnyStoryRepository, EFFunnyStoryRepository>();
        services.AddScoped<IInformationRepository, EFInformationRepository>();
        services.AddScoped<INewsRepository, EFNewsRepository>();
        services.AddScoped<IFileRepository, EFFileRepository>();
        services.AddScoped<IFooterRepository, EFFooterRepository>();

        return services;
    }
}
