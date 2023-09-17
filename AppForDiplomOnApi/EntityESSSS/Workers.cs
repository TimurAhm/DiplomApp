using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppForDiplomOnApi.EntityESSSS
{
    public class Workers
    {
        public int WorkerId { get; set; }

        public string WorkerFam { get; set; }

        public string WorkerName { get; set; }

        public string WorkerOtch { get; set; }

        public string WorkerLogin { get; set; }

        public string WorkerPassword { get; set; }

        public byte[] WorkerPicture { get; set; }
        public byte[] WorkerMyImage
        {
            get { return WorkerPicture; }
            set 
            {
                WorkerPicture = value;
                PropChange();
                
            }
        }

        public string WorkerRole { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        private void PropChange([CallerMemberName] string PropName = "")
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropName));
        }
    }
}
