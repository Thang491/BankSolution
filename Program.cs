using BankSolution.Models;
using System.Collections.Specialized;

namespace BankSolution.Program;

public class Program
{
    static void Main(string[] args)
    {
        BankBranch branch = new BankBranch();
        
        int choice = 0;
        do
        {
            Console.WriteLine("Nhập lựa chọn: ");
            Console.WriteLine("1. nhập Thông tin chi nhánh. ");
            Console.WriteLine("2. Xem thông tin của khách hàng ");
            Console.WriteLine("3. Gửi tiền ");
            Console.WriteLine("4. Rút tiền ");
            Console.WriteLine("5. In tất cả giao dịch của từng tài khoản khách hàng ");
            Console.WriteLine("6. Tài khoản có số dư lớn nhất. ");
            Console.WriteLine("7. In thông tin khách hàng theo số dư tài khoản. ");
            Console.WriteLine("8. In thông tin khách có tổng số lượng giao idhcj nhiều nhất. ");

            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    string next1 = "y";
                    do
                    {
                        Customer customer = new Customer();
                        Console.WriteLine("Nhập code: ");
                        customer.Code = Console.ReadLine();
                        Console.WriteLine("Nhập tên: ");
                        customer.Name = Console.ReadLine();
                        Console.WriteLine("Nhập địa chỉ: ");
                        customer.Address = Console.ReadLine();
                        branch.CustomerList.Add(customer);
                        string next2 = "y";
                        do
                        {
                            Console.WriteLine("Create account");
                            Account acc = new Account();
                            Console.WriteLine("Name: ");
                            acc.AccountNumber = Console.ReadLine();
                            Console.WriteLine("Money: ");
                            acc.Balance = Convert.ToDouble(Console.ReadLine());
                            if (branch.CustomerList.AccountList == null) {
                                Console.WriteLine("continue create account  ? (y/n): ");
                                next2 = Console.ReadLine();
                            } while (!next2.Equals("n")) ;

                            Console.WriteLine("Tiếp tục tạo tài khoản ? (y/n): ");
                            next1 = Console.ReadLine();
                        } while (next1 != "n");
                        break;
                    }
        } while (choice != 0) ;
        }


}
}