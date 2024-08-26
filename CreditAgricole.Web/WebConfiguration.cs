using CreditAgricole.Services;
using CreditAgricole.Services.Contracts;

public static class WebConfiguration
{
    public static string PolicyOrigin = "AllowSpecificOrigins";

    public static List<string> CorsOrigins = new List<string>() { "http://localhost:3000",
                                                      "https://localhost:3000","http://localhost:3001",
                                                      "https://localhost:3001" };
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services
            .AddScoped<IProductListService, ProductListService>()
            .AddScoped<IPricingService, PricingService>()
            .AddScoped<IProductPricesService, ProductPricesService>();

        return services;
    }


    public static IServiceCollection AddAppControllers(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        }); ;

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddCors(options =>
        {
            options.AddPolicy(name: PolicyOrigin,
                              policy =>
                              {
                                  policy.WithOrigins(CorsOrigins.ToArray());
                              });
        });
        return services;
    }
}