namespace Project;

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