namespace Code4Fun.Demo.Api.Infrastructure;

public static class OpenApiInstaller
{
    /// <summary>
    /// Adds OpenAPI/Swagger services to the specified IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add the services to.</param>
    /// <param name="openApiConfig">The OpenAPI configuration settings.</param>
    public static void AddOpenApi(this IServiceCollection services, OpenApiConfig openApiConfig)
    {
        // use auto generated documentation to enrich open api documentation
        // remember to add <GenerateDocumentationFile>true</GenerateDocumentationFile> this in csproj file 
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(openApiConfig.Version, Info(openApiConfig));
            options.IncludeXmlComments(xmlPath);
        });
    }

    /// <summary>
    /// Configures the application to use OpenAPI/Swagger.
    /// </summary>
    /// <param name="app">The IApplicationBuilder to configure.</param>
    /// <param name="openApiConfig">The OpenAPI configuration settings.</param>
    public static void UseOpenApi(this IApplicationBuilder app, OpenApiConfig openApiConfig)
    {
        app.UseStaticFiles();
        app.UseSwagger(options => options.RouteTemplate = "docs/{documentName}/docs.json");
        app.UseSwaggerUI(options =>
        {
            options.InjectStylesheet("/docs/swagger.css");
            options.SwaggerEndpoint($"/docs/{openApiConfig.Version}/docs.json", $"{openApiConfig.Title} {openApiConfig.Version}");
            options.RoutePrefix = "docs";
            options.DocumentTitle = openApiConfig.Title;
        });
    }


    /// <summary>
    /// Provides a default OpenAPI configuration.
    /// </summary>
    /// <returns>The default OpenAPI configuration.</returns>
    public static OpenApiConfig DefaultConfig()
    {
        return new()
        {
            Title = "Use config to set title",
            Version = "Use config to set version"
        };
    }

    private static OpenApiInfo Info(OpenApiConfig openApiConfig)
    {
        return new()
        {
            Title = openApiConfig.Title, 
            Version = openApiConfig.Version,
            Description = "Use this as an template for how to create a new api"
        };
    }
}