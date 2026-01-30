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

public class Achievements
{
    readonly DomainEvents domainEvents;

    public Achievements(DomainEvents domainEvents)
    {
        this.domainEvents = domainEvents;
    }

    public void TriggerRandomAchievement()
    {
        domainEvents.RandomAchievementTriggered.Invoke();
    }
}

public class DomainEvents
{
    public readonly Action FarmBought = delegate { };
    public readonly Action RandomAchievementTriggered = delegate { };
}