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
                    if (Program.UserAccounts[i].IsActive && Program.UserAccounts[i].Type == "EndUser")
                    {
                        //to call EndUserMenu method from Accounts class ...
                        EndUserMenu();
                    }
                    else if (!Program.UserAccounts[i].IsActive && Program.UserAccounts[i].Type == "EndUser")
                    {
                        Console.WriteLine("Sorry ... Your account not active yet, please contact the bank.");
                        Additional.HoldScreen();//to hold the screen ...
                    }
                    else if (Program.UserAccounts[i].IsActive && Program.UserAccounts[i].Type == "Admin")
                    {
                        //to call AdminMenu method from Accounts class ...
                        AdminMenu();
                    }
                    else
                    {
                        Console.WriteLine("Sorry ... Tis account not exist in the system (TT x TT)");
                        Additional.HoldScreen();//to hold the screen ...
                    }
                }
            }

        }
        //3.2. EndUserMenu method ...
        public static void EndUserMenu()
        {
            //to display EndUser menu options ...
            Console.WriteLine("End User Menu:");
            Console.WriteLine("1. View Account Details");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Transfer Money");
            Console.WriteLine("5. Log Out");
            //to get and validate user input for EndUser menu ...
            char endUserOption = Validation.CharValidation("option");
            //to run the option user want ...
            switch (endUserOption)
            {
                case '1':
                    //to call ViewAccountDetails method ...
                    //ViewAccountDetails();
                    break;
                case '2':
                    //to call DepositMoney method ...
                    //DepositMoney();
                    break;
                case '3':
                    //to call WithdrawMoney method ...
                    //WithdrawMoney();
                    break;
                case '4':
                    //to call TransferMoney method ...
                    //TransferMoney();
                    break;
                case '5':
                    //to log out EndUser ...
                    Console.WriteLine("You have been logged out successfully.");
                    Additional.HoldScreen();//to hold the screen ...
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Additional.HoldScreen();//to hold the screen ...
                    break;
            }
        }
        //3.3. AdminMenu method ...
        public static void AdminMenu()
        {
            //to display Admin menu options ...
            Console.WriteLine("Admin Menu:");
            Console.WriteLine("1. View All Accounts");
            Console.WriteLine("2. Activate/Deactivate Account");
            Console.WriteLine("3. Log Out");
            //to get and validate user input for Admin menu ...
            char adminOption = Validation.CharValidation("option");
            //to run the option user want ...
            switch (adminOption)
            {
                case '1':
                    //to call ViewAllAccounts method ...
                    //ViewAllAccounts();
                    break;
                case '2':
                    //to call ActivateDeactivateAccount method ...
                    //ActivateDeactivateAccount();
                    break;
                case '3':
                    //to log out Admin ...
                    Console.WriteLine("You have been logged out successfully.");
                    Additional.HoldScreen();//to hold the screen ...
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Additional.HoldScreen();//to hold the screen ...
                    break;
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
