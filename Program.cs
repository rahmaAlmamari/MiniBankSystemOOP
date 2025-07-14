namespace MiniBankSystemOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                        //SingUp();
                        Console.WriteLine("Sing up method is not implemented yet.");
                        break;

                    case '2'://to call LogIn method ...
                        //LogIn();
                        Console.WriteLine("Log in method is not implemented yet.");
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
    }
}
