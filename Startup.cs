using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using TaskMasterCSharp.Repositories;
using TaskMasterCSharp.Services;


// NOTE the XP bar only goes up, Michelle. Even if it feels bad now, it won't always.
namespace TaskMasterCSharp
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
  options.Authority = $"https://{Configuration["Auth0:Domain"]}/";
  options.Audience = Configuration["Auth0:Audience"];

});

      // NOTE This is akin the the whitelists in Node.js, allows sites listed on lines 53 & 54 to make requests to server, these methods must be finalized in configure
      services.AddCors(options =>
    {
      options.AddPolicy("CorsDevPolicy", builder =>
      {
        builder
        .WithOrigins(new string[]{
        "https://localhost:8080",
        "https://localhost:8081"

        }).AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
      });
    });

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskMasterCSharp", Version = "v1" });
      });
      services.AddScoped<IDbConnection>(x => CreateDbConnection());
      services.AddTransient<ProfileService>();
      services.AddTransient<ProfileRepository>();
      services.AddTransient<BlogService>();
      services.AddTransient<BlogRepository>();
    }

    private IDbConnection CreateDbConnection()
    {
      string connectionString = Configuration.GetSection("DB").GetValue<string>("gearhost");
      return new MySqlConnection(connectionString);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskMasterCSharp v1"));
        app.UseCors("CorsDevPolicy");
      }
      Auth0ProviderExtension.ConfigureKeyMap(new List<string>() { "id" });

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
