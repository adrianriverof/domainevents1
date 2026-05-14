namespace Project;

public interface WriteEventBus
{
    void Subscribe<T>(Action<T> action) where T : DomainEvent;
}

public interface ReadOnlyEventBus
{
    void Raise<T>(T ev) where T : DomainEvent;
}

public class DomainEvents : WriteEventBus, ReadOnlyEventBus
{
    private readonly Dictionary<Type, List<object>> _domainEvents = new(); 

    public void Subscribe<T>(Action<T> action) where T : DomainEvent
    {
        _domainEvents.TryAdd(typeof(T), new List<object>());
        _domainEvents[typeof(T)].Add(action);
    }

    public void Raise<T>(T ev) where T : DomainEvent
    {
        foreach (var action in _domainEvents[typeof(T)])
        {
            ((Action<T>)action)(ev);
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