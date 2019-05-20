using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace JK.Cube.Api
{
    public static class SwaggerConfig
    {
        private const string Url = "/swagger/v1/swagger.json";

        public static void Config(IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "CubeApi", Version = "v1", Description = "Admission test expert group .net",
                    Contact = new Contact
                    {
                        Name = "David Herrera Torres",
                        Email = "davidtorresky1@gmail.com",
                        Url = "https://www.linkedin.com/in/david-herrera-211739139/"
                    }
                });
            });
        }
        public static void Config(IApplicationBuilder app)
        {
             app.UseSwagger();
             _ = app.UseSwaggerUI(c =>
              {
                  c.SwaggerEndpoint(Url, "Cube Api V1");
              });
        }
    }
}
