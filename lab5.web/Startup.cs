namespace lab5.web;

using System.Reflection;
using dataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? Configuration.GetConnectionString("ConnectionString");

        services.AddDbContext<HospitalDbContext>(options =>
            options.UseNpgsql(connectionString));
        
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Transaction API",
                Version = "v1",
                Description = "API for transactions"
            });

            // XML-comment
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hospital API V1");
            });
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseRouting();
        app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
    
}