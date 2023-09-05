using BankSolution.Models;
using BankSolution.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankSolution.Repository
{
    public class BankRepository : IBankRepository
    {
        BankBranch branch = new BankBranch();
        Customer CustomerList = new Customer();
        double money;
        string? accountNumber;

        public void Menu()
        {
            Console.WriteLine("*****************    WELCOME TO TECHCOMBANK    *******************");
            Console.WriteLine("1. Input information. ");
            Console.WriteLine("2. View customer detail ");
            Console.WriteLine("3. Transfer Funds ");
            Console.WriteLine("4. Withdraw ");
            Console.WriteLine("5. Show all transaction ");
            Console.WriteLine("6. The account with the largest balance. ");
            Console.WriteLine("7. Show customer information according to account balance. ");
            Console.WriteLine("8. Show customer information with the most total number of transactions. ");
            Console.Write("Your choice: ");
        }
        public void InputInfor()
        {
            string next1 = "y";
            do
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Create customer ");
                Customer customer = new Customer();
                Console.Write("Code: ");
                customer.Code = Console.ReadLine();
                Console.Write("Name: ");
                customer.Name = Console.ReadLine();
                Console.Write("Address: ");
                customer.Address = Console.ReadLine();
                branch.CustomerList.Add(customer);
                string next2 = "y";
                do
                {
                    Console.WriteLine("Create account ");
                    Account acc = new Account();
                    Console.Write("Account Number: ");
                    acc.AccountNumber = Console.ReadLine();
                    Console.Write("Money: ");
                    acc.Balance = Convert.ToDouble(Console.ReadLine());
                    if (branch.CustomerList.Last().AccountList != null)
                    {
                        branch.CustomerList.Last().AccountList.Add(acc);
                    }
                    else
                    {
                        branch.CustomerList.Last().AccountList = new List<Account>();
                        branch.CustomerList.Last().AccountList.Add(acc);
                    }
                    Console.Write("continue create account ? (y/n): ");
                    next2 = Console.ReadLine();
                    Console.WriteLine("-------------------------------------");


                } while (!next2.Equals("n"));
                Console.Write("Continue create customer  (y/n): ");
                next1 = Console.ReadLine();
                Console.WriteLine("-------------------------------------");

            } while (next1 != "n");
        }
        public void ViewCus()
        {
            Console.Write("Code: ");
            string code = Console.ReadLine();
            Customer? cus = branch.GetCustomerById(code);
            if (cus == null)
            {
                Console.WriteLine("Code not Exist! ");
            }
            else
            {

                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Customer Infomation");
                Console.WriteLine($"Code: {cus.Code}");
                Console.WriteLine($"Name: {cus.Name}");
                Console.WriteLine($"Address: {cus.Address}");
                Console.WriteLine("-------------------------------------------------------");

            }
        }
        public void SendMoney()
        {
            
            Console.WriteLine("--------------------------------------------------");
            Console.Write("Input account number: ");
            accountNumber = Console.ReadLine();
            Console.Write("Input money: ");
            money = Convert.ToDouble(Console.ReadLine());
            if (this.Send(accountNumber, money))
            {
                Console.WriteLine("Successfull!!");
            }
            else
            {
                Console.WriteLine("Account not exist!!");
            }
            Console.WriteLine("---------------------------------------------------");
        }
        public void WithDraw()
        {
            Console.WriteLine("---------------------------------------------------");
            Console.Write("Input account number:");
            accountNumber = Console.ReadLine();
            Console.Write("Input money: ");
            money = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(this.withdraw(accountNumber, money));
            Console.WriteLine("--------------------------------------------------");
        }
        
        public bool Send(string accountNumber, double money)
        {
            int customerIndex = branch.CustomerList.FindIndex(cus => cus.FindAccount(accountNumber) > -1);
            if (customerIndex != -1)
            {

                int accountIndex = branch.CustomerList[customerIndex].FindAccount(accountNumber);
                branch.CustomerList[customerIndex].AccountList[accountIndex].Balance += money;
                if (branch.CustomerList[customerIndex].AccountList[accountIndex].TransactionList == null)
                {
                    branch.CustomerList[customerIndex].AccountList[accountIndex].TransactionList = new List<Transaction>();
                }
                DateTime localDate = DateTime.Now;
                Transaction transaction = new Transaction();
                transaction.Code = "T" + branch.CustomerList[customerIndex]
                    .AccountList[accountIndex].TransactionList.Count;
                transaction.DateTransaction = localDate;
                transaction.Money = money;
                transaction.Type = "D";
                branch.CustomerList[customerIndex].AccountList[accountIndex].TransactionList.Add(transaction);
                return true;
            }
            return false;
        }
        public String withdraw(string accountNumber, double money)
        {
            int customerIndex = branch.CustomerList.FindIndex(cus => cus.FindAccount(accountNumber) > -1);
            if (customerIndex != -1)
            {
                int accountIndex = branch.CustomerList[customerIndex].FindAccount(accountNumber);
                if (branch.CustomerList[customerIndex].AccountList[accountIndex].TransactionList == null)
                {
                    branch.CustomerList[customerIndex].AccountList[accountIndex].TransactionList = new List<Transaction>();
                }
                if (branch.CustomerList[customerIndex].AccountList[accountIndex].Balance > money)
                {
                    branch.CustomerList[customerIndex].AccountList[accountIndex].Balance -= money;
                    DateTime localDate = DateTime.Now;
                    Transaction transaction = new Transaction();
                    transaction.Code = "T" + branch.CustomerList[customerIndex]
                        .AccountList[accountIndex].TransactionList.Count;
                    transaction.DateTransaction = localDate;
                    transaction.Money = money;
                    transaction.Type = "W";
                    branch.CustomerList[customerIndex].AccountList[accountIndex].TransactionList.Add(transaction);
                    return "Successfull";
                }
                else
                {
                    return "Not enough money";
                }
            }
            return "Not find account number";
        }
        public void ShowAllTransaction()
        {
            if (branch.CustomerList != null)
            {
                foreach (Customer cus in branch.CustomerList)
                {
                    Console.WriteLine($"Customer Name: {cus.Name}");
                    foreach (Account acc in cus.AccountList)
                    {
                        Console.WriteLine($"Account Number: {acc.AccountNumber}");
                        if (acc.TransactionList == null)
                        {
                            acc.TransactionList = new List<Transaction>();
                        }
                        foreach (Transaction tran in acc.TransactionList)
                        {
                            Console.WriteLine($"Code {tran.Code}");
                            Console.WriteLine($"Time: {tran.DateTransaction}");
                            Console.WriteLine($"Money: {tran.Money}");
                            Console.WriteLine($"type: {tran.Type}");
                            Console.WriteLine("-------------------------------------");

                        }
                    }
                }
            }
        }
        public void ShowMaxBalanace()
        {
            double maxBalance = 0;
            foreach (Customer cus in branch.CustomerList)
            {

                if (maxBalance < cus.AccountList.Max(acc => acc.Balance))
                {
                    maxBalance = cus.AccountList.Max(acc => acc.Balance);
                }
            }
            if (maxBalance > 0)
            {
                Console.WriteLine($"Higest balance is : {maxBalance} ");
                foreach (Customer cus in branch.CustomerList)
                {
                    var maxAccount = from account in cus.AccountList
                                     where account.Balance == maxBalance
                                     select account.AccountNumber;
                    
                    foreach (string accNumber in maxAccount)
                    {
                        Console.Write("Account with the largest balance:");
                        Console.WriteLine(accNumber);
                    }

                }

            }
        }
        public void ShowBalanceTotal()
        {
            var query = from cus in branch.CustomerList
                        select new
                        {
                            customer = cus,
                            total = (from acc in cus.AccountList
                                     select acc.Balance).Sum()
                        };
            var show = query.OrderBy(o => o.total);
            foreach (var item in show)
            {
                Console.WriteLine("*************************************");
                Console.WriteLine($"Customer Name: {item.customer.Name}");
                Console.WriteLine($"Address : {item.customer.Address}");
                Console.WriteLine($"total : {item.total}");
                Console.WriteLine("-------------------------------------");
            }

        }
        public void showMaxTransaction()
        {
            var query = from cus in branch.CustomerList
                        select new
                        {
                            customer = cus,
                            quantity = (from acc in cus.AccountList
                                        select acc.TransactionList.Count()).Sum()
                        };
            var max = query.Max(o => o.quantity);
            var result = from r in query
                         where r.quantity == max
                         select r;
            foreach (var item in result)
            {
                Console.WriteLine("*************************************");
                Console.WriteLine($"Customer Name: {item.customer.Name}");
                Console.WriteLine($"Address : {item.customer.Address}");
                Console.WriteLine($"Total : {item.quantity}");
                Console.WriteLine("-------------------------------------");

            }
        }
    }
}
