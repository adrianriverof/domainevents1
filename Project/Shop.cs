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
        Console.WriteLine("Shop: Se compra una granja");
        domainEvents.Raise(new FarmBought(true));
    }
}