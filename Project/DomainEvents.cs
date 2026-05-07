namespace Project;

public interface WriteEventBus
{
    void Subscribe<T>(Action<T> action) where T : DomainEvent;
}

public class DomainEvents : WriteEventBus
{
    private readonly List<object> _domainEvents = new();

    public void Subscribe<T>(Action<T> action) where T : DomainEvent
    {
        _domainEvents.Add(action);
    }

    public void Raise<T>(T ev) where T : DomainEvent
    {
        foreach (var action in _domainEvents.OfType<Action<T>>())
        {
            action(ev);
        }
    }
}

public abstract class DomainEvent
{
}

public class FactoryBought : DomainEvent
{
}

public class FarmBought : DomainEvent
{
}