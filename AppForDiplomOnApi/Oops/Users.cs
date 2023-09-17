using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForDiplomOnApi.Oops
{
    //this code supposed to interact with calls that uses Id of User
    //because json converts like string so cant compare to int at api
    public class Users
    {
        public string UserId { get; set; }

        public string UserFam { get; set; }

        public string UserName { get; set; }

        public string UserOtch { get; set; }

        public string UserBalanceRef { get; set; }

        public string UserRole { get; set; }

        public string UserLogin { get; set; }


    }
}
