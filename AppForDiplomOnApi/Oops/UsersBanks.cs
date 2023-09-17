using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForDiplomOnApi.Oops
{
    public class UsersBanks
    {
        public string UsersBankRef { get; set; }

        public decimal UsersBankBalance { get; set; }

        public string Valuta { get; set; }
    }
}
