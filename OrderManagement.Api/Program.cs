using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace OrderManagement.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                .UseServiceProviderFactory(new MyCustomServiceFactory());
    }

    public class MyCustomServiceFactory : IServiceProviderFactory<FakeDiBuilder>
    {
        public FakeDiBuilder CreateBuilder(IServiceCollection services)
        {
            return new FakeDiBuilder(services);
        }

        public IServiceProvider CreateServiceProvider(FakeDiBuilder containerBuilder)
        {
            return containerBuilder.GetServiceProvider();
        }
    }

    public class FakeDiBuilder
    {
        private readonly IServiceCollection _services;

        public FakeDiBuilder(IServiceCollection services)
        {
            _services = services;
            _services.AddSingleton<IFakeUser, FakeUser>();
        }

        public IServiceProvider GetServiceProvider()
        {
            return new DefaultServiceProviderFactory(new ServiceProviderOptions()
            {
                ValidateScopes = false,
                ValidateOnBuild = true
            }).CreateServiceProvider(_services);
        }
    }

    public class FakeUser : IFakeUser
    {
        public string GetName()
        {
            return "Alfred Faker";
        }
    }

    public interface IFakeUser
    {
        string GetName();
    }
}
