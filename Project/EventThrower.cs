namespace Project;

public class EventThrower
{
    readonly DomainEvents domainEvents;

    public EventThrower(DomainEvents domainEvents)
    {
        this.domainEvents = domainEvents;
    }

    public void ThrowAlfa()
    {
        domainEvents.AlfaThrown.Invoke();
    }
}

public class DomainEvents
{
    public readonly Action AlfaThrown = delegate { };
}