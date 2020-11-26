namespace Shoppy.App
{
    using System;
    using System.Text.Json;
    using Autofac;
    using Shoppy.App.Os;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello to Shoppy!");

            var builder = new ContainerBuilder();

            // os
            builder.RegisterGeneric(typeof(BasketService<,>)).As(typeof(IBasketService<,>));
            builder.RegisterGeneric(typeof(ProductService<>)).As(typeof(IProductService<>));

            // project
            builder.RegisterType<ShoppyProductService>().As<IShoppyProductService>();
            builder.RegisterType<ShoppyBasketService>().As<IShoppyBasketService>();
            builder.RegisterType<DeliveryPlanningService>().As<IDeliveryPlanningService>();
            builder.RegisterType<ReviewService>().As<IReviewService>();

            var container = builder.Build();

            var basketService = container.Resolve<IShoppyBasketService>();
            var basket = basketService.GetBasket(Guid.NewGuid());

            Console.WriteLine(
                JsonSerializer.Serialize(basket, new JsonSerializerOptions { IgnoreNullValues = false, WriteIndented = true }));

            Console.WriteLine("Press the any key ;-)");
            Console.ReadKey();
        }
    }
}
