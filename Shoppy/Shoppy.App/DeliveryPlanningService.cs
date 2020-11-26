namespace Shoppy.App
{
    using System;
    using FluentDateTimeOffset;
    using Shoppy.App.Os;

    public class DeliveryPlanningService : IDeliveryPlanningService
    {
        /// <inheritdoc />
        public DeliverySlot GetChosenDeliverySlot(BasketId basketId)
        {
            var day = DateTimeOffset.Now.EndOfDay().AddDays(4);

            return new DeliverySlot { Begin = day.At(8, 00), End = day.At(17, 00) };
        }
    }
}
