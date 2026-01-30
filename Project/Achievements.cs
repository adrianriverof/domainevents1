namespace Project;

public class Achievements
{
    readonly DomainEvents domainEvents;

    public Achievements(DomainEvents domainEvents)
    {
        this.domainEvents = domainEvents;
    }

    public void TriggerFirstFarmAchievement()
    {
        domainEvents.FirstFarmAchievementTriggered.Invoke();
    }
}