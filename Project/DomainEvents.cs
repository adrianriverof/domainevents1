namespace Project;

public class DomainEvents
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

    public void Subscribe_new(Action<DomainEvent> ev)
    {
    }

    public void Raise_new(DomainEvent ev)
    {
    }
}

public abstract class DomainEvent
{
}

public class FactoryBought : DomainEvent
{
}

public class FirstFarmAchieved : DomainEvent
{
}

public class FarmBought : DomainEvent
{
    public bool IsFirst { get; }

    public FarmBought(bool isFirst)
    {
        IsFirst = isFirst;
    }
}