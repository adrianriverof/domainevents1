namespace Project;

public class Achievements : FarmBoughtListener
{
    readonly DomainEvents domainEvents;

    public Achievements(DomainEvents domainEvents)
    {
        this.domainEvents = domainEvents;
        domainEvents.Subscribe<FarmBought>(OnFarmBought);
    }

    public void OnFarmBought(FarmBought farmBought)
    {
        Console.WriteLine("A: OnFarmbought is executed");
    }
}

public interface FarmBoughtListener
{
    void OnFarmBought(FarmBought farmBought);
}