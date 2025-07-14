using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankSystemOOP
{
    class Accounts
    {
        //1. Account class feilds ...
        private int Number = 0;
        public string UserName;
        private string NationalID;
        private double Balance;
        public string PhoneNumber;
        public string Address;
        private string Password;
        public bool IsActive; // active = true or 1, inactive = false or 0
        public string Type = "EndUser";

    }
}
