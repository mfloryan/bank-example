using CTM.Bank.Domain.Aggregates;
using CTM.Bank.Domain.Events;
using CTM.Bank.Domain.Services;
using CTM.Domain.Core;
using CTM.Domain.Core.Mongo;

namespace CTM.Bank.Domain
{
    public class ApplicationHost
    {
        public static BankingApplication Configure()
        {
            var connection = new MongoConnection("mongodb://localhost");

            var repositoryFactory = Project.RegisterAllEventsInTheSameAssemblyAs<AccountCreated>()
                                           .UseThisCoolEventSourcingThang(Store.InMongo(connection.Database("Bank_Events")), Publish.ToNowhere());

            var accountAggregateRepository = new AggregateRepository<BankAccount>(repositoryFactory.CreateRepository());
            var createAccountHandler = new CreateAccountHandler(accountAggregateRepository);

            return new BankingApplication(createAccountHandler);
        } 
    }

    public class AccountAggregateRepository
    {
        
    }
}