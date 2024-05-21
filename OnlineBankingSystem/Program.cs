using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ac = new AccountManager("Accounts.txt");
            Console.WriteLine(ac.IsUserAvailable("test","ana23"));
            //var account = ac.GetAccount("123014");
            //account.Gender = "MalE";
            //ac.EditAccount(account);
            //List<BankAccount> accounts = new List<BankAccount>();

           

        }

        private static void Menu3()
        {
            Console.WriteLine("1. LogOut");
            Console.WriteLine("2. Continue");
            Console.Write("Enter your choice: ");
        }        
        private static BankAccount CreateDummyAccount()
        {
            return new BankAccount
            {
                Name = "test",
                Number = "123014",
                Balance = 1000,
                Password = "ana123",
                SecurityQuestion = "who is God",
                SecurityAnswer = "Creator",
                Gender = "Female"
            };
        }
        private static BankAccount CreateDummyAccount1()
        {
            return new BankAccount
            {
                Name = "Viva",
                Number = "123014",
                Balance = 2000,
                Password = "avui123",
                SecurityQuestion = "who is God",
                SecurityAnswer = "Creator",
                Gender = "Male"
            };
        }

        private static void Menu2(string name)
        {
            Console.WriteLine("         Welcome " + name);
            Console.WriteLine("       --------------------  ");
            Console.WriteLine("1. View account details");
            Console.WriteLine("2. Change name");
            Console.WriteLine("3. Withdraw money");
            Console.WriteLine("4. Check balance");
            Console.WriteLine("5. Transfer monney");
            Console.WriteLine("6. Change password");
            Console.WriteLine("7. Logout");
            Console.Write("Enter your choice: ");
        }

        private static void Menu1()
        {
            Console.WriteLine(" 1. Create Account (by administrator)");
            Console.WriteLine(" 2. LogIn");
            Console.WriteLine(" 3. Exit");
            Console.Write("Enter your choice: ");
        }
    }
}
