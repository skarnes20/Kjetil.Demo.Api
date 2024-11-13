public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddServiceDefaults();

        var openApiConfig = OpenApiInstaller.DefaultConfig();
        builder.Configuration.Bind("OpenApi", openApiConfig);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi(openApiConfig);
        builder.Services.AddServices();

        var app = builder.Build();

        if (builder.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseOpenApi(openApiConfig);
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
