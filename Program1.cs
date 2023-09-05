
using BankSolution.Models;
using System.Collections.Specialized;

using BankSolution.Repository;

public class Program
{
     public static void Main(string[] args)
    {
        BankRepository bank = new BankRepository();
        int choice = 0;
       
        do
        {
            bank.Menu();
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    bank.InputInfor();
                    break;
                case 2:

                    bank.ViewCus();
                    break;
                case 3:
                    bank.SendMoney();

                    break;
                case 4:
                    bank.WithDraw();
                    break;
                case 5:
                    Console.WriteLine("-------------------------------------");
                    bank.ShowAllTransaction();
                    Console.WriteLine("-------------------------------------");
                    break;
                case 6:
                    Console.WriteLine("-------------------------------------");
                    bank.ShowMaxBalanace();
                    Console.WriteLine("-------------------------------------");
                    break;
                case 7:
                    Console.WriteLine("-------------------------------------");
                    bank.ShowBalanceTotal();
                    break;
                case 8:
                    Console.WriteLine("-------------------------------------");
                    bank.showMaxTransaction();
                    break;
                
                    

            }
        } while (choice != 0);
    }


}
