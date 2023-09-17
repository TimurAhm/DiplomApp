using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForDiplomOnApi.Oops
{
    public class Credits
    {
        public string CreditUserId { get; set; }

        public string CreditType { get; set; }

        public decimal CreditCash { get; set; }

        public decimal CreditCashAfterYears { get; set; }

        public decimal CreditCashOstatok { get; set; }

        public int CreditPercent { get; set; }

        public string CreditValuta { get; set; }

        public DateTime CreditGiveDate { get; set; }

        public DateTime CreditBackDate { get; set; }
    }
}
