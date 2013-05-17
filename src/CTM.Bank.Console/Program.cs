using System;
using System.Collections.Generic;
using System.Reflection;
using CommandLine;
using CommandLine.Text;

namespace CTM.Bank.Console
{
    class Program
    {
        private static bool shouldQuit;
        static void Main()
        {
            var options = new CommandLineOptions();
            var commandLine = Parser.Default;
            do
            {
                System.Console.Write(" > ");
                var input = System.Console.ReadLine() ?? string.Empty;
                var parsingSuccessful = commandLine.ParseArguments(input.Split(' '), options, InterpretCommand);
                if (!parsingSuccessful)
                {
                    System.Console.Out.WriteLine(options.GetUsage());
                }
                
            } while(!shouldQuit);

            System.Console.Out.WriteLine("kthxbye!");
            System.Console.ReadLine();
        }

        private static void InterpretCommand(string verb, object suboptions)
        {
            if (verb.Equals("quit"))
            {
                shouldQuit = true;
            }
        }
    }

    public class CommandLineOptions
    {
        private readonly HelpText usage;

        public CommandLineOptions()
        {
            usage = new HelpText
            {
                Heading = new HeadingInfo("CTM.Bank", Assembly.GetExecutingAssembly().GetName().Version.ToString()),
                Copyright = new CopyrightInfo("comparethemarket.com", 2013),
                AdditionalNewLineAfterOption = false,
                AddDashesToOption = true
            };
            usage.AddPreOptionsLine("Usage: ");
            
            usage.AddOptions(this);
        }

        [VerbOption("quit", HelpText = "Quit the application")]
        public ApplicationCommand Quit { get; set; }
        
        [VerbOption("deposit", HelpText = "Deposit money into the account")]
        public TransactionOptions DepositAmount { get; set; }
        
        [VerbOption("withdraw", HelpText = "Withdraw money from the account")]
        public TransactionOptions WithdrawAmount { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            usage.RenderParsingErrorsText(this, 2);
            return usage;
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
