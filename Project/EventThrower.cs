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

    public void ThrowBravo()
    {
        domainEvents.BravoThrown.Invoke();
    }

    public void ThrowCharlie()
    {
        domainEvents.CharlieThrown.Invoke();
    }
}

public class DomainEvents
{
    public readonly Action AlfaThrown = delegate { };
    public readonly Action BravoThrown = delegate { };
    public readonly Action CharlieThrown = delegate { };
}