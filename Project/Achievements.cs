namespace Project;

public class Achievements
{
    readonly DomainEvents domainEvents;

    public Achievements(DomainEvents domainEvents)
    {
        this.domainEvents = domainEvents;
        domainEvents.SubscribeToFarmBought(OnFarmBought);
    }

    private void OnFarmBought(FarmBought farmBought)
    {
        TriggerFirstFarmAchievement();
    }


    private void TriggerFirstFarmAchievement()
    {
        domainEvents.FirstFarmAchievementTriggered.Invoke();
    }
}