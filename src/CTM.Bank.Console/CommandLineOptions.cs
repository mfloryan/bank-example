using System.Reflection;
using CommandLine;
using CommandLine.Text;

namespace CTM.Bank.Console
{
    public class CommandLineOptions
    {
        private readonly HelpText usage;

        public CommandLineOptions()
        {
            usage = new HelpText
                {
                    Heading = new HeadingInfo("CTM.Bank", Assembly.GetExecutingAssembly().GetName().Version.ToString()),
                    AdditionalNewLineAfterOption = false,
                    AddDashesToOption = true
                };
            usage.AddPreOptionsLine("Copyright © comparethemarket.com");
            usage.AddPreOptionsLine("Usage: ");
            
            usage.AddOptions(this);
        }

        [VerbOption("quit", HelpText = "Quit the application")]
        public ApplicationCommand Quit { get; set; }
        
        [VerbOption("help", HelpText = "Print this message")]
        public ApplicationCommand Help { get; set; }
        
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
}