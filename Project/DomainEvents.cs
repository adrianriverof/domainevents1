namespace Project;

public class DomainEvents
{
    private readonly List<Action<FarmBought>> _farmBoughtActions = new();
    private readonly List<Action<FirstFarmAchieved>> _firstFarmAchievedActions = new();
    private readonly List<Action<DomainEvent>> _domainEvents = new();

    public void Raise<T>(T ev) where T : DomainEvent
    {
        foreach (var action in _domainEvents.OfType<Action<T>>())
        {
            action(ev);
        }
    }

    public void Subscribe<T>(Action<T> action) where T : DomainEvent
    {
        Action<DomainEvent> apply = ev => action.Invoke((T)ev); 
        _domainEvents.Add(apply);
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