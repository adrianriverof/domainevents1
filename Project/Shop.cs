namespace Project;

public class Shop
{
    readonly DomainEvents domainEvents;

    public Shop(DomainEvents domainEvents)
    {
        this.domainEvents = domainEvents;
    }

    public void BuyFarm()
    {
        domainEvents.FarmBought.Invoke();
    }
}