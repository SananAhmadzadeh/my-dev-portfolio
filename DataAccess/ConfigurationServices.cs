namespace DataAccess
{
    public static class ConfigurationServices
    {
        extension(IServiceCollection services)
        {
            public IServiceCollection AddDataAccessConfiguration(IConfiguration configuration)
            {
                services.AddDbContext<EducationDbContext>(options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString("Default"));
                });

                services.AddScoped<IUnitOfWork, UnitOfWork.Concrete.UnitOfWork>();

                return services;
            }
        }
    }
}
