namespace Project;

public class Achievements
{
    readonly DomainEvents domainEvents;

    public Achievements(DomainEvents domainEvents)
    {
        this.domainEvents = domainEvents;
        domainEvents.FarmBought += OnFarmBought;
    }

    private void OnFarmBought()
    {
        TriggerFirstFarmAchievement();
    }

    public void TriggerFirstFarmAchievement()
    {
        domainEvents.FirstFarmAchievementTriggered.Invoke();
    }
}