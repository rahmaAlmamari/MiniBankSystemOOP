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
        public bool IsActive; // active = true or 1, inactive = false or 0
        public string Type = "EndUser";

        //2. Accounts class Properites ...

        //3. Accounts class methods ...
        
        //4. Account class constructors ...
        //4.1. Default constructor ...
        public Accounts() 
        {
            AccountNumber++;//to set AccountNumber as auto-increment by 1 ...
        }

    }
}
