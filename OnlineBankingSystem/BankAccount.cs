using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingSystem
{
    public class BankAccount
    {
        private string _accountName = "viva";
        private string _accountNumber;
        private decimal _accountBalance = 1000;
        private string _accountPassword = "123";
        private string _securityQuestion = "Who is God?";
        private string _gender;
        private string _securityAnswer = "creator";
        public bool State { get; set; } = true;

        public string Name
        {
            get { return _accountName; }
            set { _accountName = value; }
        }
        public string Number
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }
        public decimal Balance
        {
            get { return _accountBalance; }
            set { _accountBalance = value; }
        }
        public string Password
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
    }
}
