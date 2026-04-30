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

    class MockAchievements : FarmBoughtListener
    {
        public bool HasFarmBoughtBeenTriggered;

        public MockAchievements(DomainEvents domainEvents)
        {
            domainEvents.Subscribe<FarmBought>(OnFarmBought);
        }

        public void OnFarmBought(FarmBought farmBought)
        {
            HasFarmBoughtBeenTriggered = true;
        }
    }
}