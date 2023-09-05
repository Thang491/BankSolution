using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSolution.Models;

public class Transaction
{
    public string Code { get; set; }
    public DateTime DateTransaction  { get; set; }
    public double Money { get; set; }
    public string Type { get; set; }

    
}


