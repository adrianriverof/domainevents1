using Project;

namespace Tests;

public class Tests
{
    [Test]
    public void AchievementTest()
    {
        var domainEvents = new DomainEvents();
        var achievements = new MockAchievements(domainEvents);
        var shop = new Shop(domainEvents);

        shop.BuyFarm();

        Assert.That(achievements.HasBeenExecuted, Is.True);
    }

    class MockAchievements : Dasdfgqsdfg
    {
        public bool HasBeenExecuted;

        public MockAchievements(DomainEvents domainEvents)
        {
            domainEvents.Subscribe<FarmBought>(OnFarmBought);
        }

        public void OnFarmBought(FarmBought farmBought)
        {
            HasBeenExecuted = true;
        }
    }
}