using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using SmartCash.ApplicationDBContext;

namespace SmartCash
{
    class Program
    {
        static void Main(string[] args)
            {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Smart Cash",
                    Version = "v1"
                });
            });

            builder.Services.AddDbContext<ApplicationDbContext>(Options => 
                Options.UseSqlite("Data Source=myapp.db"));

            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Smart Cash v1"); 
                    options.RoutePrefix = string.Empty; 
                });
            }

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
