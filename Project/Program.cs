using System;
using System.Globalization;
using Project.Entities;
using Project.Services;

namespace Project {
    public class Program {
        public static void Main(string[] args) {

            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double totalValue = double.Parse(Console.ReadLine());
            Console.Write("Enter number of installments: ");
            int installments = int.Parse(Console.ReadLine());

            Contract contract = new Contract(number, date, totalValue);

            ContractService contractService = new ContractService(new PayPalService());
            contractService.ProcessContract(contract, installments);

            Console.WriteLine("Installments:");
            foreach (Installment inst in contract.Installments) {
                Console.WriteLine(inst.ToString());
            }
        }
    }
}