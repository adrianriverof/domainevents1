using Project;

namespace Tests;

public class Tests {
	[SetUp]
	public void Setup() { }

	[Test]
	public void Test1() {
		Assert.Pass();
	}

	[Test]
	public void Subscription_doesnt_break()
	{
		DomainEvents domainEvents = new DomainEvents();
		_ = new Achievements(domainEvents);
		
		Assert.Pass();
	}

	[Test]
	public void Event_list_contains_Farmbought()
	{
		DomainEvents domainEvents = new DomainEvents();
		_ = new Achievements(domainEvents);

		Assert.That(domainEvents.DomainEventActionList[0], Is.TypeOf<Action<FarmBought>>());
	}
	
}