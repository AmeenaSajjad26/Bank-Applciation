using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmeenaC_sharp2
{
    public class Customer
    {
        private string userId;
        private int password;
        private int checkingNum;
        private int savingNum;
        private int checkingBal;
        private int savingBal;

        public Customer()
        {
        }

        //constructor with arguments
        public Customer(string name, int pin, int cN, int sN, int cB, int sB)
        {
            this.UserId = name;
            this.Password = pin;
            this.CheckingNum = cN;
            this.SavingNum = sN;
            this.CheckingBal = cB;
            this.SavingBal = sB;
        }

        public string UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }

        public int Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public int CheckingNum
        {
            get
            {
                return checkingNum;
            }
            set
            {
                checkingNum = value;
            }
        }

        public int SavingNum
        {
            get
            {
                return savingNum;
            }
            set
            {
                savingNum = value;
            }
        }

        public int CheckingBal
        {
            get
            {
                return checkingBal;
            }
            set
            {
                checkingBal = value;
            }
        }

        public int SavingBal
        {
            get
            {
                return savingBal;
            }
            set
            {
                savingBal = value;
            }
        }

    }//end of class Customer
}//end of namespace
