namespace DataAccess
{
    public static class ConfigurationServices
    {
        extension(IServiceCollection services)
        {
            public IServiceCollection AddDataAccessConfiguration(IConfiguration configuration)
            {
                var connectionString = Environment.GetEnvironmentVariable("Connection__String")
                                       ?? configuration.GetConnectionString("Default"); // local üçün fallback

                if (string.IsNullOrWhiteSpace(connectionString))
                    throw new Exception("Connection string is not set!");

                services.AddDbContext<EducationDbContext>(options =>
                {
                    options.UseNpgsql(connectionString);
                });


                services.AddScoped<IUnitOfWork, UnitOfWork.Concrete.UnitOfWork>();

                return services;
            }
        }
    }
}
