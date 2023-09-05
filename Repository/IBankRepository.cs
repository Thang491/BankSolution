using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSolution.Repository
{
    public interface IBankRepository
    {
        void Menu();
        void InputInfor();
        void ViewCus();
        void SendMoney();
        void WithDraw();
        bool Send(string accountNumber, double money);
        String withdraw(string accountNumber, double money);
        void ShowAllTransaction();
        void ShowMaxBalanace();
        void ShowBalanceTotal();
        void showMaxTransaction();

    }
}
