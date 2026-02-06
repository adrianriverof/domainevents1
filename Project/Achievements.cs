namespace Project;

public class Achievements
{
    readonly DomainEvents domainEvents;

    public Achievements(DomainEvents domainEvents)
    {
        this.domainEvents = domainEvents;
        domainEvents.Subscribe<FarmBought>(OnFarmBought);
    }

    private void OnFarmBought(FarmBought farmBought)
    {
        if (farmBought.IsFirst)
        {
            TriggerFirstFarmAchievement();
        }
    }

    private void TriggerFirstFarmAchievement()
    {
        domainEvents.Raise(new FirstFarmAchieved());
    }
}