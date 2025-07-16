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
        //USD value (1 USD = 3.8 OMR)
        public const double USD = 3.8;
        //EUR value (1EUR = 0.45 OMR)
        public const double EUR = 0.45;
        //Rate Service list ...
        public static List<int> Rating = new List<int>();//to store user rate on the service used ...
        //Transactions list to store all transactions done by the user ...
        public static List<Transactions> AccountTransactions = new List<Transactions>();

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
            set { Balance = value; }
        }

        //==============================3. Accounts class methods=======================================
        //------------------------------3.1. EndUser Use Case ------------------------------------------
        //3.1.1. EndUserMenu method ...
        public static void EndUserMenu(string nationalId)
        {
            //to get user ifnormation from UserAccounts list based on the nationalId ...
            Accounts userAccount = Program.UserAccounts.Find(x => x.P_NationalID == nationalId);
            //to keep the EndUserMenu method runs until user choose to closed it ...
            bool EndUserMenuRun = true;//to stop the EndUserMenu method ...
            while (EndUserMenuRun)
            {
                Console.Clear();//to clear the screen ...
                Console.WriteLine($"Welcome {userAccount.UserName} your account number is {userAccount.AccountNumber}\n"+
                                  $"Please feel free to use our services:");
                Console.WriteLine("1. Deposite money");//to put money to your account ...
                Console.WriteLine("2. Withdraw money");//to take money from your account ...
                Console.WriteLine("3. Check balance");//to know how much in your account ...
                Console.WriteLine("4. Submit review");//to submit message with what you like and what not to the admin ...
                Console.WriteLine("5. Transfer money between accounts");
                Console.WriteLine("6. Undo last complaint submitted");
                Console.WriteLine("7. Update Account Information");
                Console.WriteLine("8. Print All Account Transactions");
                Console.WriteLine("9. Show Last N Transactions");
                Console.WriteLine("10. Show Transactions After Date X");
                Console.WriteLine("11. Monthly Statement Generator");
                Console.WriteLine("12. Booking Bank Services");
                Console.WriteLine("0. Exsit");
                //to call CharValidation to get and validate user input ...
                string EndUserMenuOption = Validation.StringValidation("option");
                //to run the option user want ...
                switch (EndUserMenuOption)
                {
                    case "1"://to call DepositeMoney method ...
                        DepositeMoney();
                        break;

                    case "2"://to call WithdrawMoney method ...
                        //WithdrawMoney();
                        break;

                    case "3"://to call CheckBalance method ...
                        CheckBalance();
                        break;

                    case "4"://to call SubmitReview method ...
                        //SubmitReview(nationalId);
                        break;

                    case "5"://to call TransferBetweenAccounts method ...
                        //TransferBetweenAccounts();
                        break;

                    case "6"://to call UndoLastComplaintSubmitted method ...
                        //UndoLastComplaintSubmitted(nationalId);
                        break;

                    case "7"://to call UpdateAccountInfo method ...
                        //UpdateAccountInfo(nationalId);
                        break;

                    case "8": //to call PrintAllAccountTransactions method ...
                        //PrintAllAccountTransactions();
                        break;

                    case "9": //to call ShowLastNTransactions method ..
                        //ShowLastNTransactions();
                        break;

                    case "10": //to call ShowTransactionsAfterDateX method ..
                        //ShowTransactionsAfterDateX();
                        break;

                    case "11": //to call MonthlyStatementGenerator method ..
                        //MonthlyStatementGenerator();
                        break;

                    case "12"://to call BookingBankServices method ...
                        //BookingBankServices(nationalId);
                        break;

                    case "0"://to exsit EndUserMenu ...
                        EndUserMenuRun = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Additional.HoldScreen();//to hold the screen ...
                        break;
                }

            }
        }
        //3.1.2. DepositeMoney method ...
        public static void DepositeMoney()//to put money to your account ...
        {
            //to enter the account number from the user ...
            int AccountNumber;
            AccountNumber = Validation.IntValidation("account number");
            //to check if the account exist ...
            bool IsExist = CheckAccountNumberExist(AccountNumber);
            if (!IsExist)
            {
                Console.WriteLine("Sorry the account number you entered is not exist!");
                Additional.HoldScreen();//just to hold a second ...
                return; //to stop the method ...
            }
            else
            {
                //to get currencies (OMR,USD, EUR) from the user ...
                char currency;
                Console.WriteLine("Available currencies:");
                Console.WriteLine("1. OMR");
                Console.WriteLine("2. USD");
                Console.WriteLine("3. EUR");
                //to call CharValidation to get and validate user input ...
                currency = Validation.CharValidation("currency (1,2,3)");
                //to deposite money in the account based on the currency selected by the user ...
                switch (currency)
                {
                    case '1': //to deposite OMR ...
                        ToGetDepositeMoney(1, AccountNumber, "Deposite (OMR)");
                        break;
                    case '2': //to deposite USD ...
                        ToGetDepositeMoney(USD, AccountNumber, "Deposite (USD)");
                        break;
                    case '3': //to deposite EUR ...
                        ToGetDepositeMoney(EUR, AccountNumber, "Deposite (EUR)");
                        break;
                    default:
                        Console.WriteLine("Invalid currency choice.");
                        Additional.HoldScreen();//to hold the screen ...
                        break;
                }
            }
        }
        //3.1.3. Withdraw money ...
        public static void WithdrawMoney()
        {
            //to enter the account number from the user ...
            int AccountNumber;
            AccountNumber = Validation.IntValidation("account number");
            //to check if the account exist ...
            bool IsExist = CheckAccountNumberExist(AccountNumber);
            if (!IsExist)
            {
                Console.WriteLine("Sorry the account number you entered is not exist!");
                Additional.HoldScreen();//just to hold a second ...
                return; //to stop the method ...
            }
            else
            {
                //to do the process of withdraw money ...
                double WithdrawMoney = Validation.DoubleValidation("money amount to deposite");
                //get account money amount using check balance ... do it after login ...
                //to get money amount in the account ... it will be in the balance leater ...
                double AccountMoney = 0;
                int index = 0;
                for (int i = 0; i < Program.UserAccounts.Count; i++)
                {
                    if (Program.UserAccounts[i].AccountNumber == AccountNumber)
                    {
                        AccountMoney = Program.UserAccounts[i].P_Balance;
                        index = i;
                        break;//to stop the loop and save the time ...
                    }
                }
                double Withdraw = AccountMoney - WithdrawMoney;
                bool IsValid = CheckBalanceEqualsMinimumBalance(Withdraw);
                if (!IsValid)
                {
                    Console.WriteLine("Sorry your withdraw process is not complete");
                    Additional.HoldScreen();//just to hold the screen ...
                }
                else
                {
                    Program.UserAccounts[index].P_Balance = Withdraw;
                    Console.WriteLine($"Your withdraw process done successfully.\n" +
                                      $"Your new balance is: {Withdraw}");
                    //to store the transaction details in the lists ...
                    StoreTransactions("Withdraw", WithdrawMoney,Withdraw);
                    //to get user rate on service ...
                    RateService("withdraw");
                }
            }
        }//to take money from your account ... 
        //3.1.4. Check balance ...
        public static void CheckBalance()
        {
            //to enter the account number from the user ...
            int AccountNumber;
            AccountNumber = Validation.IntValidation("account number");
            //to check if the account exist ...
            bool IsExist = CheckAccountNumberExist(AccountNumber);
            if (!IsExist)
            {
                Console.WriteLine("Sorry the account number you entered is not exist!");
                Additional.HoldScreen();//just to hold a second ...
                return; //to stop the method ...
            }
            else
            {
                for (int i = 0; i < Program.UserAccounts.Count; i++)
                {
                    if (AccountNumber == Program.UserAccounts[i].AccountNumber)
                    {
                        Console.WriteLine($"Your account balance is: {Program.UserAccounts[i].P_Balance}");
                        Additional.HoldScreen();
                        return;//to stop the method ...
                    }
                }
            }
        }//to know how much in your account ...
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
                string adminOption = Validation.StringValidation("option");
                //to run the option user want ...
                switch (adminOption)
                {
                    case "1":
                        //to call ViewAllAccounts method ...
                        ViewAllAccountsOpenRequests();
                        break;
                    case "2":
                        //to call ApproveRequestsAccountsOpening method ...
                        ApproveRequestsAccountsOpening();
                        break;
                    case "3":
                        //to log out Admin ...
                        Console.WriteLine("You have been logged out successfully.");
                        Additional.HoldScreen();//to hold the screen ...
                        break;
                    case "0"://to exsit AdmainMenuRun ...
                        AdmainMenuRun = false;
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
                        EndUserMenu(inputNational);
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
        //3.3.2. CheckAccountNumberExist method to check if the account number exist or not...
        public static bool CheckAccountNumberExist(int accountNum)
        {
            //20 8 9 19 3 15 4 5 13 1 4 5 2 25 18 1 8 13 1 1 12 13 1 13 1 18 9
            bool result = false;
            for (int i = 0; i < Program.UserAccounts.Count; i++)
            {
                if (Program.UserAccounts[i].AccountNumber == accountNum)
                {
                    result = true;
                    break;//to step the loop and save the time ...
                }
            }
            return result;
        }
        //3.1.3. ToGetDepositeMoney method ...
        public static void ToGetDepositeMoney(double CurrencyValue, int AccountNumber, string type)
        {
            //to do the process of deposite money ...
            double DepositeMoney = Validation.DoubleValidation("money amount to deposite");
            //get account money amount using check balance ... do it after login ...
            //to get money amount in the account ... it will be in the balance leater ...
            double AccountMoney = 0;
            int index = 0;
            for (int i = 0; i < Program.UserAccounts.Count; i++)
            {
                if (Program.UserAccounts[i].AccountNumber == AccountNumber)
                {
                    AccountMoney = Program.UserAccounts[i].P_Balance;
                    index = i;
                    break;//to stop the loop and save the time ...
                }
            }
            double Deposite = AccountMoney + (DepositeMoney * CurrencyValue);
            Program.UserAccounts[index].P_Balance = Deposite;
            Console.WriteLine($"Your deposite process done successfully.\n" +
                              $"Your new balance is: {Deposite}");
            Additional.HoldScreen();//to hold the screen ...
            //to store the transaction details in the lists ...
            StoreTransactions(type, (DepositeMoney * CurrencyValue), Deposite);
            //to get user rate on service ...
            RateService("deposite");
        }
        //3.1.5. StoreTransactions method to store the transaction details in the lists ...
        public static void StoreTransactions(string type, double amount, double balance)
        {
            //to create a new transaction object ...
            Transactions transaction = new Transactions()
            {
                TransactionType = type,
                TransactionAmount = amount,
                TransactionBalance = balance,
                TransactionDate = DateTime.Now
            };
            //to add the transaction to the AccountTransactions list ...
            AccountTransactions.Add(transaction);
            Console.WriteLine("Transction add successfully");
            Additional.HoldScreen();//to hold the screen ...
        }
        //3.3.5. To rate the Service method
        public static void RateService(string ServiceName)
        {
            Console.WriteLine($"Please rate our {ServiceName} service from 1 to 5:");
            //to get the rate from the user ...
            int rating = Validation.IntValidation("rating (1 to 5)");
            //to store the rating in the Ratings list ...
            Rating.Add(rating);
            Console.WriteLine($"Thank you for rating our {ServiceName} service with {rating} stars.");
            Additional.HoldScreen();//just to hold second ...
        }
        //3.3.6. Check if balance < MinimumBalance ...
        public static bool CheckBalanceEqualsMinimumBalance(double value)
        {
            bool IsValide;
            if (value < MinimumBalance)
            {
                IsValide = false;
                Console.WriteLine($"Your {value} amount is lass then minimum balance: {MinimumBalance}");
                Additional.HoldScreen();//to hold the screen ...

            }
            else
            {
                IsValide = true;
            }
            return IsValide;
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
