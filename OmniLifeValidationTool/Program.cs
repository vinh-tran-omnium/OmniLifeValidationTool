using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OmniLifeValidationTool.Database;
using OmniLifeValidationTool.Services;

namespace OmniLifeValidationTool
  {
  [System.Runtime.Versioning.SupportedOSPlatform("windows")]
  static class Program
    {
    public static IServiceProvider? ServiceProvider { get; private set; }

    [STAThread]
    static void Main()
      {
      Application.SetHighDpiMode(HighDpiMode.SystemAware);
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      var host = CreateHostBuilder().Build();
      ServiceProvider = host.Services;

      Application.Run(ServiceProvider.GetRequiredService<Form1>());
      }


    static IHostBuilder CreateHostBuilder()
      {
      return Host.CreateDefaultBuilder()
          .ConfigureServices((context, services) =>
          {
            // Forms
            services.AddTransient<Form1>();

            // Repository
            services.AddTransient<IPremiumRepository, PremiumRepository>();

            // Services
            services.AddTransient<IPremiumService, PremiumService>();

          });
      }
    }
  }