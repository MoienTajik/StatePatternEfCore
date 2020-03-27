using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StatePatternEfCore.Data;
using StatePatternEfCore.Domain.Order;
using System;

namespace StatePatternEfCore
{
    public static class Program
    {
        public static void Main()
        {
            ServiceProvider serviceProvider = ConfigureServices();

            var order = new Order("Hat", 2500);
            order.State.Confirm();
            order.State.Ship("Tehran");

            Console.WriteLine($"Order before save to DB: {order}");

            // Persist
            var db = serviceProvider.GetService<ApplicationDbContext>();
            db.Orders.Add(order);
            db.SaveChanges();

            Order retrievedOrder = db.Orders.Find(1);
            Console.WriteLine($"Order retrieved from DB: {retrievedOrder}");

            Console.ReadKey();
        }

        private static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseInMemoryDatabase("OrdersDB"));

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}