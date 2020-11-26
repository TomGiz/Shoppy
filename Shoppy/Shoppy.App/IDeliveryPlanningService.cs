namespace Shoppy.App
{
    using Shoppy.App.Os;

    public interface IDeliveryPlanningService
    {
        DeliverySlot GetChosenDeliverySlot(BasketId basketId);
    }
}