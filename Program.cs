namespace MiniBankSystemOOP
{
    internal class Program
    {
        //to store EndUser accounts in a list ...
        public static List<Accounts> UserAccounts = new List<Accounts>();
        //to set Admin account with default values ...
        public static Accounts AdminAccount = new Accounts()
        {
            UserName = "11admin11",
            //P_NationalID = Validation.StringValidation("national id"),
            P_NationalID = "1199",
            PhoneNumber = "0123456789",
            Address = "Admin Address",
            P_Password = "1199",
            IsActive = true,
            Type = "Admin"
        };
        //the main method of the program ...
        static void Main(string[] args)
        {
            //to add Admin account to UserAccounts list ...
            UserAccounts.Add(AdminAccount);
            //to call WelcomeMessage method ...
            Additional.WelcomeMessage();
            //to keep the system runs until user choose to closed the system ...
            bool MainRun = true;//to stop main method ...
            while (MainRun)
            {
                Console.Clear();//to clear the screen ...
                Console.WriteLine("1. Sing up");
                Console.WriteLine("2. Log in");
                Console.WriteLine("0. Log out");
                //to call CharValidation to get and validate user input ...
                char MainOption = Validation.CharValidation("option");
                //to run the option user want ...
                switch (MainOption)
                {
                    case '1'://to call SingIn method ...
                        SingUp();
                        break;

                    case '2'://to call LogIn method from Accounts class ...
                        //to get and validate user input for login ...
                        string inputNational = Validation.StringValidation("national id");
                        string inputPassword = Validation.StringValidation("password");
                        Accounts.LogIn(inputNational, inputPassword);
                        break;

                    case '0'://to log out Main ...
                        //to display exit message ...
                        Console.WriteLine("Have a nice day (^0^)");
                        MainRun = false;//to stop the while loop ...
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Additional.HoldScreen();//to hold the screen ...
                        break;
                }

            }
        }
        //SingUp method ...
        public static void SingUp()
        {
            //to get user input and validate it ...
            string UserName = Validation.StringNamingValidation("user name");
            string NationalID = Validation.StringValidation("national id");
            string PhoneNumber = Validation.StringValidation("phone number");
            string Address = Validation.StringValidation("address");
            string Password = Validation.StringValidation("password");
            //to create new account ...
            Accounts NewAccount = new Accounts()
            {
                UserName = UserName,
                P_NationalID = NationalID,
                PhoneNumber = PhoneNumber,
                Address = Address,
                P_Password = Password,
            };
            //to add the new account to the list of EndUser accounts ...
            UserAccounts.Add(NewAccount);
            Console.WriteLine("Your account has been created successfully (^0^)");
            Additional.HoldScreen();//to hold the screen ...

        }
    }
}
