namespace Project;

public class Achievements : FarmBoughtListener
{
    public Achievements(DomainEvents domainEvents)
    {
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