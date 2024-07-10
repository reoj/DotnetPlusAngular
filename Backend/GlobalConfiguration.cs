using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public static class GlobalConfiguration
{
    public static Action<SwaggerGenOptions> ConfigureSwaggerGenOptions()
    {
        return static cnfg =>
        {
            cnfg.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Title = "Productiv WebAPI",
                    Description = "A learning exercise to Understand API development",
                    Contact = new OpenApiContact
                    {
                        Name = "Developer Name Goes Here",
                        Email = "developer_email@here.com",
                        Url = new Uri("https://github.com/reoj")
                    },
                    Version = "v1"
                }
            );
        };
    }
}
