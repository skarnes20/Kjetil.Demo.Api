namespace Kjetil.Demo.Api.Infrastructure;

public static class OpenApiInstaller
{
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

    public static void UseOpenApi(this IApplicationBuilder app, OpenApiConfig openApiConfig)
    {
        app.UseStaticFiles();
        app.UseSwagger(options => options.RouteTemplate = "docs/{documentName}/docs.json");
        app.UseSwaggerUI(options =>
        {
            options.InjectStylesheet("/swagger-ui/custom.css");
            options.SwaggerEndpoint($"/docs/{openApiConfig.Version}/docs.json", $"{openApiConfig.Title} {openApiConfig.Version}");
            options.RoutePrefix = "docs";
            options.DocumentTitle = openApiConfig.Title;
        });
    }

    public static OpenApiConfig DefaultConfig()
    {
        return new()
        {
            Title = "Kjetil.Demo.Api",
            Version = "1.0"
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