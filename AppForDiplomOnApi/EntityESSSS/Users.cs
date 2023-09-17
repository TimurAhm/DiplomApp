using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForDiplomOnApi.EntityESSSS
{
    public class Users
    {
        public int UserId { get; set; }

        public string UserFam { get; set; }

        public string UserName { get; set; }

        public string UserOtch { get; set; }

        public string UserBalanceRef { get; set; }

        public string UserRole { get; set; }

        public string UserLogin { get; set; }

    }
}
