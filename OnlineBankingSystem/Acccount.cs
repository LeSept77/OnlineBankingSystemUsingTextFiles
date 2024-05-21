using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingSystem
{
    internal class Account
    {
        private string _accountName = "viva";
        private string _accountNumber;
        private decimal _accountBalance = 1000; 
        private string _accountPassword = "123";
        private string _securityQuestion ="Who is God?";
        private string _gender;
        private string _securityAnswer =  "creator";
		public bool State { get; set; } = true;

        public string AcountName
		{
			get { return _accountName; }
			set { _accountName = value; }
		}
       	public string AccountNumber
		{
			get { return _accountNumber; }
			set { _accountNumber = value; }
		}
       	public decimal AcountBalance
		{
			get { return _accountBalance; }
			set { _accountBalance = value; }
		}
       	public string AccountPassword
        {
			get { return _accountPassword; }
			set { _accountPassword = value; }
		}
		public string SecurityQuestion
		{
			get { return _securityQuestion; }
			set { _securityQuestion = value.ToLower(); }
		}
		public string SecurityAnswer
		{
			get { return _securityAnswer; }
			set { _securityAnswer = value; }
		}
		public string Gender
		{
			get { return _gender; }
			set { _gender = value; }
		}
		public void Getinfo()
		{
			Random rand = new Random();
			AccountNumber = rand.Next(1001, 1999).ToString();
			Console.WriteLine("Enter Account name:");
			_accountName = Console.ReadLine();
            Console.WriteLine("Enter Account password:");
            AccountPassword = Console.ReadLine();
            Console.WriteLine("Enter gender:");
            Gender = Console.ReadLine();
            AcountBalance = 1000.00m;
            Console.WriteLine("Enter security question:");
            SecurityQuestion = Console.ReadLine();
            Console.WriteLine("Enter security answer:");
            SecurityAnswer = Console.ReadLine();
			Console.Clear();
			Console.WriteLine("Account Created successfully. Returning to main menu");
			System.Threading.Thread.Sleep(3000);
			Console.Clear();

		}
		public void DisplayInfo()
		{
			Console.WriteLine("Name: "+AcountName);
            Console.WriteLine("Gender "+Gender);
            Console.WriteLine("Password: "+AccountPassword);
            Console.WriteLine("Balance: "+_accountBalance);
            Console.WriteLine("Acount number: "+AccountNumber);
            Console.WriteLine("Security question: "+SecurityQuestion);
            Console.WriteLine("Security Answer: "+SecurityAnswer);
            Console.WriteLine("Press any key to continue ");
            Console.ReadLine();
        }
		public void ResetPassword()
		{
			Console.WriteLine(SecurityQuestion + '?');
			bool result = CheckSecurityQuestion(Console.ReadLine());            
            if (result == true)
			{
                Console.WriteLine("Enter new Password");
                AccountPassword = Console.ReadLine();

                Console.WriteLine("Password changed Successfully");
                Console.WriteLine("Press any key to continue ");
                Console.ReadLine();
            }
			else
			{
                Console.WriteLine("Wrong Security answer");
                Console.WriteLine("Press any key to continue ");
                Console.ReadLine();
            }
		}
		public bool CheckSecurityQuestion(string answer)
		{
			if (answer.ToLower()==SecurityAnswer)
			{
				return true;
			}
			return false;
		}
		public void ChangeName()
		{
			Console.WriteLine("Enter new name:");
			_accountName = Console.ReadLine();
            Console.WriteLine("Name changed successfuly");
            Console.WriteLine("Press any key to continue ");
            Console.ReadLine();
        }
		public void DisplayBalace()
		{
			Console.WriteLine(_accountBalance);
            Console.WriteLine("Press any key to continue ");
            Console.ReadLine();
        }
		public void Withdraw()
		{
			Console.Write("Enter amount to withdraw:");
			decimal amount = decimal.Parse(Console.ReadLine());
            amount = Math.Round(amount);
			if (amount <= AcountBalance)
			{
				AcountBalance -= amount;
				Console.WriteLine("withdraw done successfuly");
                Console.WriteLine("Press any key to continue ");
                Console.ReadLine();
            }
			else
			{
				Console.WriteLine("Insufficient amount");
                Console.WriteLine("Press any key to continue ");
                Console.ReadLine();
            }
		}
        public void Transfer()
        {
            Console.Write("Enter amount to transfer:");
            decimal amount = decimal.Parse(Console.ReadLine());
			amount = Math.Round(amount);
			if (amount <= AcountBalance)
			{
				AcountBalance -= amount;
				Console.WriteLine("transfer done successfuly");
				Console.WriteLine("Press any key to continue ");
				Console.ReadLine();
			}
			else
			{
				Console.WriteLine("Insufficient amount");
                Console.WriteLine("Press any key to continue ");
                Console.ReadLine();
            }
        }
		public bool LogIn()
		{
			int maxtrial = 3;
			for (int i = 1; i <= maxtrial; i++)
			{
				if (i>1)
				{
					bool result = CheckUsernamePasswordAndSecurityQuestion();
					if (result == true)
					{
						return true;
					}
				}
				else
				{
                    bool result = CheckUsernameAndPassword();
					if (result == true)
                    {
                        return true;
                    }
                }
       
			}
			State = false;
			Console.WriteLine("you account is blocked. contact Admin");
			return false;

		}
        
        private bool CheckUsernameAndPassword()
		{
            Console.Write("Enter Account name:");
            string name = Console.ReadLine();
            Console.Write("Enter Account password:");
            string password = Console.ReadLine();

            if (name == _accountName && password == AccountPassword)
            {
                return true;

            }
			Console.WriteLine("Username or Password not correct");
			return false;
        }		
		private bool CheckUsernamePasswordAndSecurityQuestion()
		{
            Console.Write("Enter Account name:");
            string name = Console.ReadLine();
            Console.Write("Enter Account password:");
            string password = Console.ReadLine();
            Console.Write(SecurityQuestion);
            string answer = Console.ReadLine();
            if (name == _accountName && password == AccountPassword && answer == SecurityAnswer)
            {
                return true;

            }
            Console.WriteLine("Username or Password or security answer not correct");
            return false;
        }
	
    }
}
