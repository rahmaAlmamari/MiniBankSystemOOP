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
        private double Balance = 100;
        public string PhoneNumber;
        public string Address;
        private string Password;
        public bool IsActive = false; // active = true or 1, inactive = false or 0
        public string Type = "EndUser";// Type can be "EndUser" or "Admin" ...
        //MinimumBalance Constant to set Minimum balance allowed in the account ...
        public const double MinimumBalance = 100.0;

        //==============================================================================================
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
        public double P_Balance
        {
            get { return Balance; }
            //set
            //{
            //    //to get and validate Balance input ...
            //    if (value >= MinimumBalance)
            //    {
            //        Balance = value;
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Balance can not be less than {MinimumBalance}.");
            //        Additional.HoldScreen();//to hold the screen ...
            //    }
            //}
        }

        //==============================3. Accounts class methods=======================================
        //------------------------------3.1. EndUser Use Case ------------------------------------------
        //3.1.1. EndUserMenu method ...
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
        //-------------------------------------- 3.2. Admin UseCase ------------------------------------
        //3.2.1. AdminMenu method ...
        public static void AdminMenu()
        {
            //to keep the AdmainMenu method runs until user choose to closed it ...
            bool AdmainMenuRun = true;//to stop the AdmainMenu method ...
            while (AdmainMenuRun)
            {
                Console.Clear();//to clear the screen ...
                Console.WriteLine("Admin Menu:");
                Console.WriteLine("1. View All Accounts Open Requests");
                Console.WriteLine("2. Approve requests accounts opening");
                Console.WriteLine("3. View opinging accounts in the system");
                Console.WriteLine("4. View all review in the system");
                Console.WriteLine("5. Add new admin");
                Console.WriteLine("6. Delete Account");
                Console.WriteLine("7. Search for account");
                Console.WriteLine("8. Show total bank balance");
                Console.WriteLine("9. Show Top 3 Richest Customers");
                Console.WriteLine("10. Export All Account Info to a New File");
                Console.WriteLine("11. Unlock Locked Accounts");
                Console.WriteLine("12. Print All Transactions");
                Console.WriteLine("13. View Average Feedback Score");
                Console.WriteLine("14. Approve reguests for loan");
                Console.WriteLine("15. Approve reguests for account consultation");
                Console.WriteLine("0. Exsit");
                //to get and validate user input for Admin menu ...
                char adminOption = Validation.CharValidation("option");
                //to run the option user want ...
                switch (adminOption)
                {
                    case '1':
                        //to call ViewAllAccounts method ...
                        ViewAllAccountsOpenRequests();
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
        }
        //3.2.2. ViewAllAccountsOpenRequests method ...
        public static void ViewAllAccountsOpenRequests()
        {
            //to check if there are request or not ...
            if (Program.AccountOpenRequests.Count == 0)
            {
                Console.WriteLine("There is no request submited yet");
                Additional.HoldScreen();//to hold the screen ...
                return;//to stop the method ...
            }
            //to display all the request submited ...
            foreach (Accounts request in  Program.AccountOpenRequests)
            {
                Console.WriteLine($"User Name: {request.UserName}\n"+
                                  $"National ID: {request.P_NationalID}\n"+
                                  $"Phone Number: {request.PhoneNumber}\n"+
                                  $"Address: {request.Address}\n" +
                                  $"Balance: {request.P_Balance}" +
                                  $"Password: {request.P_Password}\n"+
                                  $"Is Active: {request.IsActive}\n"+
                                  $"Type: {request.Type}");
                Console.WriteLine("----------------------");
            }

            Additional.HoldScreen();//to hold the screen ...
        }
        //3.2.3. ApproveRequestsAccountsOpening method ...
        public static void ApproveRequestsAccountsOpening()
        {
            //to check if there are request or not ...
            if (Program.AccountOpenRequests.Count == 0)
            {
                Console.WriteLine("There is no request submited yet");
                Additional.HoldScreen();//to hold the screen ...
                return;//to stop the method ...
            }
            //to get first request submited to AccountOpenRequests queue ...
            Accounts request = Program.AccountOpenRequests.Dequeue();
            Console.WriteLine($"User Name: {request.UserName}\n" +
                              $"National ID: {request.P_NationalID}\n" +
                              $"Phone Number: {request.PhoneNumber}\n" +
                              $"Address: {request.Address}\n" +
                              $"Balance: {request.P_Balance}" +
                              $"Password: {request.P_Password}\n" +
                              $"Is Active: {request.IsActive}\n" +
                              $"Type: {request.Type}");

            bool action = Additional.ConfirmAction("approved this request");
            if (action)
            {
                //to get account index in UserAccounts list ...
                int index = Program.UserAccounts.FindIndex(x => x.P_NationalID == request.P_NationalID);
                //to set the request account as active in UserAccounts list...
                Program.UserAccounts[index].IsActive = true;
                //to remove the request account from AccountOpenRequests queue ...
                Program.AccountOpenRequests.Dequeue();
                Console.WriteLine("Request approved successfully.");
                Additional.HoldScreen();//to hold the screen ...
            }
            else
            {
                Console.WriteLine("Request not approved.");
                Additional.HoldScreen();//to hold the screen ...
            }
        }
        //------------------------------------- 3.3. Additional Methods --------------------------------
        //3.3.1. LogIn method ... 
        public static void LogIn(string inputNational, string inputPassword)
        {
            //to loop through UserAccounts list to find the account that match the input ...
            for (int i = 0; i < Program.UserAccounts.Count; i++)
            {
                if (Program.UserAccounts[i].P_NationalID == inputNational &&
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
                //return;
            }

        }

        //==============================================================================================
        //4. Account class constructors ...
        //4.1. Default constructor ...
        public Accounts() 
        {
            AccountNumber++;//to set AccountNumber as auto-increment by 1 ...
        }

    }
}
