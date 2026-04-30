namespace Project;

public class Achievements : Dasdfgqsdfg
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

public interface Dasdfgqsdfg
{
    void OnFarmBought(FarmBought farmBought);
}