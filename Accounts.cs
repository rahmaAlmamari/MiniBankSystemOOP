using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankSystemOOP
{
    class Accounts
    {
        //1. Accounts class feilds ...
        private int AccountNumber = 0;
        public string UserName;
        private string NationalID;
        private double Balance;
        public string PhoneNumber;
        public string Address;
        private string Password;
        public bool IsActive = false; // active = true or 1, inactive = false or 0
        public string Type = "EndUser";// Type can be "EndUser" or "Admin" ...
        //MinimumBalance Constant to set Minimum balance allowed in the account ...
        public const double MinimumBalance = 100.0;

        //2. Accounts class Properites ...
        public string P_NationalID
        {
            get { return NationalID; }
            set
            {
                //to get and validate NationalID input ...
                NationalID = value;
            }
        }
        public string P_Password
        {
            get { return Password; }
            set
            {
                //to get and validate Password input ...
                Password = value;
            }
        }

        //3. Accounts class methods ...
        //3.1. LogIn method ... 
        public static void LogIn(string inputNational, string inputPassword)
        {
            //to loop through UserAccounts list to find the account that match the input ...
            for (int i = 0; i <= Program.UserAccounts.Count; i++)
            {
                if(Program.UserAccounts[i].P_NationalID == inputNational &&
                   Program.UserAccounts[i].P_Password == inputPassword)
                {
                    //to check if the account is active ...
                    if (!Program.UserAccounts[i].IsActive && Program.UserAccounts[i].Type == "EndUser")
                    {
                        //to display welcome message ...
                        Console.WriteLine($"Welcome our deer end user {Program.UserAccounts[i].UserName} to Codeline Bank System");
                        Additional.HoldScreen();//to hold the screen ...
                        //to call EndUserMenu method from Accounts class ...
                        //EndUserMenu();
                    }
                    else if (Program.UserAccounts[i].IsActive && Program.UserAccounts[i].Type == "Admin")
                    {
                        //to display welcome message ...
                        Console.WriteLine($"Welcome our deer admin {Program.UserAccounts[i].UserName} to Codeline Bank System");
                        Additional.HoldScreen();//to hold the screen ...
                        //to call AdminMenu method from Accounts class ...
                        //AdminMenu();
                    }
                    else
                    {
                        Console.WriteLine("Your account is inactive, please contact the bank.");
                        Additional.HoldScreen();//to hold the screen ...
                    }
                    return;//to exit the method after finding the account ...
                }
            }

        }

        //4. Account class constructors ...
        //4.1. Default constructor ...
        public Accounts() 
        {
            AccountNumber++;//to set AccountNumber as auto-increment by 1 ...
        }

    }
}
