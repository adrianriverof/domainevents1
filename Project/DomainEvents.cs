namespace Project;

public class DomainEvents
{
    private readonly List<Action<FarmBought>> _farmBoughtActions = new();
    private readonly List<Action<FirstFarmAchieved>> _firstFarmAchievedActions = new();
    private readonly List<Action<DomainEvent>> _domainEvents = new();

    public List<Action<DomainEvent>> DomainEventActionList => _domainEvents;

    public void Raise<T>(T ev) where T : DomainEvent
    {
        Console.WriteLine(">>Empieza a emitir eventos");
        Console.WriteLine($"R: Raise evento de tipo: {ev}");
        Console.WriteLine($"R: Numero de eventos suscritos de este tipo: {_domainEvents.OfType<Action<T>>().Count()}");
        foreach (var action in _domainEvents.OfType<Action<T>>())
        {
            Console.WriteLine("---");
            Console.WriteLine($"R: Se emite el evento: {action}");
            Console.WriteLine($"R: Le pasamos el ev: {ev}");
            action(ev);
        }
        Console.WriteLine(">> Ha terminado de emitir eventos");
    }

    public void Subscribe<T>(Action<T> action) where T : DomainEvent
    {
        var type = typeof(T);
        Console.WriteLine($">> S: [SUSCRIBIR] para el tipo: {type.Name}");
        _domainEvents.Add(ev =>
        {
            Console.WriteLine($"S (funcion enviada): Ejecutándose lo que se suscribió: {ev}");
            if (ev is T specificEvent)
            {
                Console.WriteLine($"S(f): Ha pasado el if de specificEvent: {specificEvent}");
                action(specificEvent);
            }
            else
            {
                Console.WriteLine($"S(f): La función que intenta ejecutarse no es del tipo {type}");
            }
        });
        Console.WriteLine(">> Ha terminado de suscribirse");
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