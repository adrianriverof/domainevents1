namespace Project;

public class Achievements : FarmBoughtListener, FactoryBoughtListener
{
    public Achievements(WriteEventBus domainEvents)
    {
        domainEvents.Subscribe<FarmBought>(OnFarmBought);
        domainEvents.Subscribe<FactoryBought>(OnFactoryBought);
    }

    public void OnFarmBought(FarmBought farmBought)
    {
        Console.WriteLine("A: OnFarmBought is executed");
    }

    public void OnFactoryBought(FactoryBought factoryBought)
    {
        Console.WriteLine("A: OnFactoryBought is executed");
    }
}

public interface FarmBoughtListener
{
    void OnFarmBought(FarmBought farmBought);
}

public interface FactoryBoughtListener
{
    void OnFactoryBought(FactoryBought factoryBought);
}