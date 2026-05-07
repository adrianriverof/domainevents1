using Project;

namespace Tests;

public class Tests
{
    [Test]
    public void BuyFarmTriggersFarmBoughtAchievement()
    {
        var domainEvents = new DomainEvents();
        var achievements = new MockAchievements(domainEvents);
        var shop = new Shop(domainEvents);

        shop.BuyFarm();

        Assert.That(achievements.HasFarmBoughtBeenTriggered, Is.True);
    }

    [Test]
    public void BuyFactoryTriggerFactoryBoughtAchievement()
    {
        var domainEvents = new DomainEvents();
        var achievements = new MockAchievements(domainEvents);
        var shop = new Shop(domainEvents);

        shop.BuyFactory();

        Assert.That(achievements.HasFactoryBoughtBeenTriggered, Is.True);
    }

    [Test]
    public void BuyFactoryDoesNotTiggerFarmBought()
    {
        var domainEvents = new DomainEvents();
        var achievements = new MockAchievements(domainEvents);
        var shop = new Shop(domainEvents);

        shop.BuyFactory();

        Assert.That(achievements.HasFarmBoughtBeenTriggered, Is.False);
    }

    [Test]
    public void BuyFarmDoesNotTiggerFactoryBought()
    {
        var domainEvents = new DomainEvents();
        var achievements = new MockAchievements(domainEvents);
        var shop = new Shop(domainEvents);

        shop.BuyFarm();

        Assert.That(achievements.HasFactoryBoughtBeenTriggered, Is.False);
    }

    [Test]
    public void NothingGetsTriggeredWhenNothingHappens()
    {
        var domainEvents = new DomainEvents();
        var achievements = new MockAchievements(domainEvents);

        Assert.That(achievements.HasFactoryBoughtBeenTriggered, Is.False);
        Assert.That(achievements.HasFarmBoughtBeenTriggered, Is.False);
    }

    class MockAchievements : FarmBoughtListener, FactoryBoughtListener
    {
        public bool HasFarmBoughtBeenTriggered;
        public bool HasFactoryBoughtBeenTriggered;

        public MockAchievements(DomainEvents domainEvents)
        {
            domainEvents.Subscribe<FarmBought>(OnFarmBought);
            domainEvents.Subscribe<FactoryBought>(OnFactoryBought);
        }

        public void OnFarmBought(FarmBought farmBought)
        {
            HasFarmBoughtBeenTriggered = true;
        }

        public void OnFactoryBought(FactoryBought factoryBought)
        {
            HasFactoryBoughtBeenTriggered = true;
        }
    }
}