using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_practise
{
    class HappyBirthday
    {
        //Parameter part of class
        //All parameters of the class are defined here
        private string birthdayMessage;
        private string presentString;
        //private int numberOfPresents;
        //private bool party;

        //Constructor part of class
        //All constructors of the class are defined here
        public HappyBirthday()
        {
            //default constructor
            //numberOfPresents = 0;
            //party = false;

            //Inheritance example
            birthdayMessage = "Happy Birthday ";
            presentString = "Number of presents: ";
        }

        //Method part of class
        //All methods of the class are defined here
        public string myMessage
        {
            get { return birthdayMessage; }
            set { birthdayMessage = getMessage(value); }
        }

        /*
         private string getMessage(string givenName)
        {
            string message;
            message = "Happy Birthday " + givenName + "!!!\n";
            //message = message + "Number of Presents = " + numberOfPresents.ToString();
            //
            //if (!party)
            //{
            //    message = message + "\nNo party - Sorry!";
            //}
            //else
            //{
            //    message = message + "\nHope you enjoy the party!";
            //}

            return message;
        }
        */
        //public int PresentCount
        //{
        //   set { numberOfPresents = value;  }
        //}

        //public bool HaveParty
        //{
        //    set { party = value; }
        //}


        //down from here is inheritance example, above - classes example
        public string getPresents(int numPresents)
        {
            presentString = presentString + numPresents.ToString();
            return presentString;
        }
        public string getMessage(string name)
        {
            birthdayMessage = birthdayMessage + name;
            return birthdayMessage;
        }
    }
}
