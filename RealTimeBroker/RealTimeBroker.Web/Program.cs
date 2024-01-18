//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;

using RealTimeBroker.Web.HostedServices;
using RealTimeBroker.Web.Hubs;

namespace RealTimeBroker.Web
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      

 

      builder.Services.AddCors(options =>
      {
        options.AddPolicy("CorsPolicy", builder => builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
      });

      builder.Services.AddControllers();

      builder.Services.AddSignalR();
      builder.Services.AddHostedService<UpdateStockPriceHostedService>();


      var app = builder.Build();

      app.UseHttpsRedirection();
      app.UseCors("CorsPolicy");

      app.MapHub<BrokerHub>("/brokerhub");

      app.Run();

    }


  }
}
