using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankSolution.Models;

public class BankBranch
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Customer> CustomerList { get; set; }

    public BankBranch()
    {
        CustomerList = new List<Customer>();
    }


    public Customer? GetCustomerById(string CustomerId)
    {

        return this.CustomerList.SingleOrDefault(cus => cus.Code.Equals(CustomerId));
    }
    public Boolean IsCustomerExist(string id)
    {
        return this.CustomerList.Any(cus => cus.Code.Equals(id));
    }

    public Customer? GetCustomer(string code)
    {
        Customer? customer = this.CustomerList.SingleOrDefault(cus => cus.Code.Equals(code));
        return customer;
    }
    
}
