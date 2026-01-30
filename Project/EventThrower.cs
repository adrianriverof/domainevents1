namespace Project;

public class EventThrower
{
    public void ThrowEvent()
    {
        DomainEvents.ThrownEvent.Invoke();
    }
}


public static class DomainEvents
{
    public static readonly Action ThrownEvent = delegate { };
}



