using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BankSolution.Models;

public class Customer
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Account> AccountList { get; set; }

    public void AddAccount(Account acc)
    {
        this.AccountList.Add(acc);
    }

    public bool IsAccountExist(string code)
    {
        return AccountList.Any(acc=> acc.AccountNumber.Equals(code));
    }

    public int FindAccount(string accountNumber)
    {
        return AccountList.FindIndex(acc=> acc.AccountNumber.Equals(accountNumber));
    }

}
