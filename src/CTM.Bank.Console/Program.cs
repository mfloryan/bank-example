using System.Collections.Generic;
using CTM.Bank.Domain;
using CommandLine;

namespace CTM.Bank.Console
{
    class Program
    {
        static void Main()
        {
            var options = new CommandLineOptions();
            var commandLine = Parser.Default;

            var bank = new BankingApplication();

            System.Console.WriteLine("Welcome to the CTM.Bank, please use the following commands:");
            System.Console.Out.WriteLine(options.GetUsage());
            do
            {
                System.Console.Write(" > ");
                var input = System.Console.ReadLine() ?? string.Empty;
                var parsingSuccessful = commandLine.ParseArguments(input.Split(' '), options, (verb, additionalOptions) => BankingVerb.From(verb).Execute(bank, additionalOptions));
                if (!parsingSuccessful)
                {
                    System.Console.Out.WriteLine(options.GetUsage());
                }
                
            } while(bank.IsOpen);

            System.Console.Out.WriteLine("kthxbye!");
            System.Console.ReadLine();
        }
    }

    public class ApplicationCommand
    {
        [ValueList(typeof(List<string>))]
        public IList<string> AdditionalData { get; set; }
    }

    public class TransactionOptions
    {
        [ValueList(typeof(List<string>), MaximumElements = 1)]
        public IList<string> Amount { get; set; }
    }
}
