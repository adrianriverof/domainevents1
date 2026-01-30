namespace Project;

public class EventThrower
{
    readonly DomainEvents domainEvents;

    public EventThrower(DomainEvents domainEvents)
    {
        this.domainEvents = domainEvents;
    }

    public void BuyFarm()
    {
        domainEvents.FarmBought.Invoke();
    }

    public void ClickGoldenCookie()
    {
        domainEvents.GoldenCookieClicked.Invoke();
    }
}

public class DomainEvents
{
    public readonly Action FarmBought = delegate { };
    public readonly Action GoldenCookieClicked = delegate { };
}