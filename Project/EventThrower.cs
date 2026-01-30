namespace Project;

public class EventThrower
{
    readonly DomainEvents domainEvents;

    public EventThrower(DomainEvents domainEvents)
    {
        this.domainEvents = domainEvents;
    }

    public void ThrowEvent()
    {
        domainEvents.ThrownEvent.Invoke();
    }
}

public class DomainEvents
{
    public readonly Action ThrownEvent = delegate { };
}