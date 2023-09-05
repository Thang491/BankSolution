using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSolution.Models;

public class Account
{
    public string AccountNumber { get; set; }
    public double Balance { get; set; }

    public List<Transaction> TransactionList { get; set; }


}
