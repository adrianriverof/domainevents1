namespace Project;

public class DomainEvents
{
    private readonly List<Action<FarmBought>> _farmBoughtActions = new();

    public Action FirstFarmAchievementTriggered = delegate { };

    public void RaiseFarmBought(FarmBought ev)
    {
        foreach (var action in _farmBoughtActions)
        {
            action(ev);
        }
    }

    public void SubscribeToFarmBought(Action<FarmBought> action)
    {
        _farmBoughtActions.Add(action);
    }
}

public struct FarmBought
{
    public bool IsFirst { get; }

    public FarmBought(bool isFirst)
    {
        IsFirst = isFirst;
    }
}