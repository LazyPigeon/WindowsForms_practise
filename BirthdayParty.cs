using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_practise
{
    class BirthdayParty : HappyBirthday
    {
        //Parameters


        //Constructors
        public BirthdayParty():base()
        {

        }

        //Methods
        public string getParty(bool haveParty)
        {
            if (haveParty == true)
            {
                return "Enjoy your party!";
            }
            else
            {
                return "Sorry - No party for you!";
            }
        }

        public string getParty(bool haveParty, string name)
        {
            if (haveParty == true)
            {
                return "Enjoy your party! " + name;
            }
            else
            {
                return "Sorry - No party for you! " + name;
            }
        }
    }
}
