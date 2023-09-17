using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForDiplomOnApi.Oops
{
    public class UserInforms
    {
        public string UserInformUserId { get; set; }

        public int UserInformPassportSeria { get; set; }

        public int UserInformNomer { get; set; }

        public string UserInformWorkPlace { get; set; }

        public string UserInformFamilyType { get; set; }

        public string UserInformRealEstate { get; set; }

        public decimal UserInformIncome { get; set; }
    }
}
