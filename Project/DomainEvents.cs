namespace Project;

public class DomainEvents
{
    private readonly List<Action<FarmBought>> _farmBoughtActions = new();
    private readonly List<Action<FirstFarmAchieved>> _firstFarmAchievedActions = new();

    public void RaiseFarmBought(FarmBought ev)
    {
        foreach (var action in _farmBoughtActions)
        {
            action(ev);
        }
    }

    public void RaiseFirstFarmAchieved(FirstFarmAchieved ev)
    {
        foreach (var action in _firstFarmAchievedActions)
        {
            action(ev);
        }
    }

    public void SubscribeToFarmBought(Action<FarmBought> action)
    {
        _farmBoughtActions.Add(action);
    }

    public void SubscribeToFirstFarmAchieved(Action<FirstFarmAchieved> action)
    {
        _firstFarmAchievedActions.Add(action);
    }
}

public struct FirstFarmAchieved
{
}

public struct FarmBought
{
    public bool IsFirst { get; }

    public FarmBought(bool isFirst)
    {
        IsFirst = isFirst;
    }
}