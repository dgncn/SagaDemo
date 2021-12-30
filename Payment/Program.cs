using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaymentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Payment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var bus = RabbitHutch.CreateBus("host=localhost:5672;username=guest;password=guest");

                    services.AddSingleton<IBus>(bus);
                    services.AddSingleton<MessageDispatcher>();
                    services.AddSingleton<AutoSubscriber>(_ =>
                    {
                        return new AutoSubscriber(_.GetRequiredService<IBus>(), Assembly.GetExecutingAssembly().GetName().Name)
                        {
                            AutoSubscriberMessageDispatcher = _.GetRequiredService<MessageDispatcher>()
                        };
                    });

                    services.AddScoped<StockReservedEventConsumer>();

                    services.AddHostedService<Worker>();
                });
    }
}
