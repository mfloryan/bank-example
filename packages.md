# Intro to the `Domain.Core` packages

To get into a clean state ready for adding packages run: `git checkout adding-packages`

1. Go to: Tools > Library Package Manager > Package Manager Settings > Package Sources
	* Make sure the CTM Nuget Repository at: `http://pbo-ctmbuild01:8012/nuget` is added to your list of available package sources, if not add it and call it something like: `CTM Nuget Repository`
2. Right Click on the `CTM.Bank.Domain` project and click on 'Manage NuGet Packages'
	* Select the CTM NuGet Repository
	* Find the `CTM.Domain.Core` package and click Install
	* Wait & Curse VisualStudio and Microsoft for their frustrating package management system
	* Then, bask in your ability to follow simple instructions
3. In the `CTM.Bank.Domain` project add a new class, call it something like: `ApplicationHost` use the following code to setup Domain.Core:

	public class ApplicationHost
    {
        public static BankingApplication Configure()
        {
            var connection = new MongoConnection("mongodb://localhost");

            var repositoryFactory = Project.RegisterAllEventsInTheSameAssemblyAs<AccountCreated>()
                                           .UseThisCoolEventSourcingThang(Store.InMongo(connection.Database("bank_events")), Publish.ToNowhere());

            return new BankingApplication();
        } 
    }
	
Rather than creating a `new BankingApplication()` in `Program.cs` replace it with a call to: `ApplicationHost.Configure()` we can then use `ApplicationHost` as our simple DI container.

4. The observant amongst you will have noticed that the `AccountCreated` class does not exist and so it won't compile :(  Go ahead and create it in `CTM.Bank.Domain.Events`, this will 
be our first event (that was quick wasn't it?) so let's also make it inherit from `CTM.Domain.Core.Event`

5. Create an `Account` class in `CTM.Bank.Domain.Aggregates` this will be our AggregateRoot so it should inherit from `CTM.Domain.Core.AggregateRoot`. 
Let's also create a test for it in `CTM.Bank.Tests.Unit.Aggregates` (the tests that we're going to write for accounts are going to be blazingly fast so they are Unit tests)
your first test might look something like this: 

	[Test]
	public void ShouldPublishAnAccountCreatedEvent()
	{
		var account = new Account(AggregateDescriptor.New());
		Assert.That(account.UncommittedEvents.Count, Is.EqualTo(1));
	}
 
at this point we will also need to add the `CTM.Domain.Core` NuGet package to the test project, for this use the same process as above.