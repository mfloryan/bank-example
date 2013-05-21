using CTM.Bank.Domain;
using CTM.Bank.Domain.Control;

namespace CTM.Bank.Console
{
    class Program
    {
        static void Main()
        {
            var bank = ApplicationHost.Configure();

            System.Console.WriteLine("Welcome to the CTM.Bank, please use the following commands:");
            do
            {
                System.Console.Write(" > ");
                var input = System.Console.ReadLine() ?? string.Empty;
                System.Console.Out.WriteLine("  " + BankingVerb.From(input).Execute(bank));

            } while(bank.IsOpen);

            System.Console.Out.WriteLine("kthxbye!");
            System.Console.ReadLine();
        }
    }
}
