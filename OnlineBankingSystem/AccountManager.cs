using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingSystem
{
    public class AccountManager
    {
        private string _fileName;
        public AccountManager(string fileName)
        {
            _fileName = fileName;
        }
        public void CreateFile()
        {
            using (var writer = new StreamWriter(_fileName))
            {
                writer.WriteLine("Name;Number;Balance;Password;SecurityQuestion;SecurityAnswer;Gender");
            }
        }
        public List<BankAccount> GetAllAccounts()
        {
            List<BankAccount> allAccounts = new List<BankAccount>();
            List<string> accountLines = File.ReadAllLines(_fileName).ToList();

            // Remove the header line (if present)
            accountLines.RemoveAt(0);

            foreach (string line in accountLines)
            {
                string[] parts = line.Split(';');
                BankAccount account = new BankAccount()
                {
                    Name = parts[0],
                    Number = parts[1],
                    Balance = Convert.ToDecimal(parts[2]),
                    Password = parts[3],                   
                    SecurityQuestion = parts[4],
                    SecurityAnswer = parts[5],
                    Gender = parts[6]
                };
                allAccounts.Add(account);
            }
            return allAccounts;

        }       
        public BankAccount? GetAccount(string number)
        {
            List<BankAccount> allAccounts = new List<BankAccount>();
            List<string> accountLines = File.ReadAllLines(_fileName).ToList();

            // Remove the header line (if present)
            accountLines.RemoveAt(0);

            foreach (string line in accountLines)
            {
                string[] parts = line.Split(';');
                BankAccount account = new BankAccount()
                {
                    Name = parts[0],
                    Number = parts[1],
                    Balance = Convert.ToDecimal(parts[2]),
                    Password = parts[3],                   
                    SecurityQuestion = parts[4],
                    SecurityAnswer = parts[5],
                    Gender = parts[6]
                };
                allAccounts.Add(account);
            }
            return allAccounts.Where(p => p.Number == number).FirstOrDefault();

        }
        public void CreateAccount(BankAccount account)
        {
            using (StreamWriter writer = new StreamWriter(_fileName, true)) // 'true' for append mode
            {
                writer.Write($"{account.Name};"); // Example product data
                writer.Write($"{account.Number};"); // Example product data
                writer.Write($"{account.Balance};"); // Example product data
                writer.Write($"{account.Password};"); // Example product data
                writer.Write($"{account.SecurityQuestion};"); // Example product data
                writer.Write($"{account.SecurityAnswer};"); // Example product data
                writer.WriteLine($"{account.Gender}"); // Example product data                
            }
        }        
        public void EditAccount(BankAccount accountPassed)
        {
            var accounts = GetAllAccounts();
            var accountInDb = accounts.Where(a=>a.Number== accountPassed.Number).FirstOrDefault();
            if (accountInDb!=null)
            {
                accountInDb.Name = accountPassed.Name;
                accountInDb.Number = accountPassed.Number;
                accountInDb.Balance = accountPassed.Balance;
                accountInDb.Password = accountPassed.Password;
                accountInDb.SecurityQuestion = accountPassed.SecurityQuestion;
                accountInDb.SecurityAnswer = accountPassed.SecurityAnswer;
                accountInDb.Gender = accountPassed.Gender;
            }
            CreateFile();
            using (StreamWriter writer = new StreamWriter(_fileName, true)) // 'true' for append mode
            {
                foreach (var account in accounts)
                {
                    writer.Write($"{account.Name};"); // Example product data
                    writer.Write($"{account.Number};"); // Example product data
                    writer.Write($"{account.Balance};"); // Example product data
                    writer.Write($"{account.Password};"); // Example product data
                    writer.Write($"{account.SecurityQuestion};"); // Example product data
                    writer.Write($"{account.SecurityAnswer};"); // Example product data
                    writer.WriteLine($"{account.Gender}"); // Example product data          
                }      
            }
        }
        public void PrintAllAccounts(List<BankAccount> accounts)
        {
            foreach (BankAccount account in accounts) 
            { 
                Console.WriteLine($"Name:{account.Name}");
                Console.WriteLine($"Number:{account.Number}");
                Console.WriteLine($"Balance:{account.Balance}");
                Console.WriteLine($"Password:{account.Password}");
                Console.WriteLine($"Security Question:{account.SecurityQuestion}");
                Console.WriteLine($"Security Answer:{account.SecurityAnswer}");
                Console.WriteLine($"Gender:{account.Gender}");
                Console.WriteLine($"------------------------------------------------------");
            }
        }
        public bool IsUserAvailable(string name,string password) 
        {
            List<BankAccount> allAccounts = new List<BankAccount>();
            List<string> accountLines = File.ReadAllLines(_fileName).ToList();

            // Remove the header line (if present)
            accountLines.RemoveAt(0);

            foreach (string line in accountLines)
            {
                string[] parts = line.Split(';');
                BankAccount account = new BankAccount()
                {
                    Name = parts[0],
                    Number = parts[1],
                    Balance = Convert.ToDecimal(parts[2]),
                    Password = parts[3],
                    SecurityQuestion = parts[4],
                    SecurityAnswer = parts[5],
                    Gender = parts[6]
                };
                allAccounts.Add(account);
            }
            return allAccounts.Any(a=>a.Name==name && a.Password == password);
        }         

    }
}
