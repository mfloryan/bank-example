using CTM.Bank.Domain.Events;
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
                                           .UseThisCoolEventSourcingThang(Store.InMongo(connection.Database("bank_events")), Publish.ToNowhere());

            return new BankingApplication();
        } 
    }
}