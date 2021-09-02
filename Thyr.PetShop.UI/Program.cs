using System;
using Microsoft.Extensions.DependencyInjection;
using Petshop.Core.iServices;
using Petshop.Domain.IRepository;
using Petshop.Domain.Services;
using Petshop.Infrastructure.Data.Repositories;


namespace Thyr.PetShop.UI
{
    class Program
    {
        private static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetShopRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPetTypeService, PetTypeService>();
            serviceCollection.AddScoped<IPetTypeRepository, PetShopRepository>();
            serviceCollection.AddScoped<IMenu, Menu>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var menu = serviceProvider.GetRequiredService<IMenu>();
            menu.Start();
        }
    }
}