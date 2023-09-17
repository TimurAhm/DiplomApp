using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppForDiplomOnApi.PagesS
{
    /// <summary>
    /// Interaction logic for UserBankAddPage.xaml
    /// </summary>
    public partial class UserBankAddPage : Page
    {
        public UserBankAddPage()
        {
            InitializeComponent();
        }

        private void btSaveAddBankClick(object sender, RoutedEventArgs e)
        {
            SaveBank();
        }

        private async void SaveBank()
        {
            Oops.UsersBanks objBanks = new Oops.UsersBanks();
            objBanks.UsersBankRef = tbUsersBankRef.Text;
            objBanks.UsersBankBalance = Convert.ToInt64(tbUsersBankBalance.Text);
            objBanks.Valuta = tbValuta.Text;
            string json = JsonConvert.SerializeObject(objBanks);
            var baseAdress = "http://localhost:5000/api/UsersBank?UsersBankRef" + tbUsersBankRef.Text + "&UsersBankBalance=" +
                tbUsersBankBalance.Text + "&Valuta=" + tbValuta.Text;
            var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAdress));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";
            string parsedContent = json;
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] bytes = encoding.GetBytes(parsedContent);
            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();
            var response = await Task.Run(() => http.GetResponseAsync());
            var stream = response.GetResponseStream();
            NavigationService.Navigate(new UsersBankAllInfoPage());
        }

        private void btCancelAddBankClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
