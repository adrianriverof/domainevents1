namespace Project;

public class Shop
{
    readonly ReadOnlyEventBus domainEvents;

    public Shop(ReadOnlyEventBus domainEvents)
    {
        this.domainEvents = domainEvents;
    }

    public void BuyFarm()
    {
        domainEvents.Raise(new FarmBought());
    }

    public void BuyFactory()
    {
        domainEvents.Raise(new FactoryBought());
    }
}