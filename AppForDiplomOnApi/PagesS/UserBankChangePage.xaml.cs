using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for UserBankChangePage.xaml
    /// </summary>
    public partial class UserBankChangePage : Page
    {
        Oops.UsersBanks usersBanks1;
        public UserBankChangePage(Oops.UsersBanks usersBanks)
        {
            this.usersBanks1 = usersBanks;
            InitializeComponent();
            DataContext = usersBanks1;
        }

        private void btSaveChangeBankClick(object sender, RoutedEventArgs e)
        {
            SaveEditUser();
        }

        private async void SaveEditUser()
        {
            if (tbUsersBankBalance != null && tbUsersBankRef != null && tbValuta != null)
            {
                try
                {
                    Oops.UsersBanks objBanks = new Oops.UsersBanks();
                    //  int a = Convert.ToString(tbUserIdP.Text);
                    objBanks.UsersBankRef = tbUsersBankRef.Text;
                    objBanks.UsersBankBalance = Convert.ToInt64(tbUsersBankBalance.Text);
                    objBanks.Valuta = tbValuta.Text;
                    string json = JsonConvert.SerializeObject(objBanks);
                    var baseAdress = "http://localhost:5000/api/UsersBank/UsersBankRef?UsersBankRef=" + tbUsersBankRef.Text.ToString() + "&UsersBankBalance=" + tbUsersBankBalance.Text + "&Valuta=" +
                        tbValuta.Text;
                    var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAdress));
                    http.Accept = "application/json";
                    http.ContentType = "application/json";
                    http.Method = "PUT";
                    string parsedContent = json;
                    UTF8Encoding encoding = new UTF8Encoding();
                    Byte[] bytes = encoding.GetBytes(parsedContent);
                    Stream newStream = http.GetRequestStream();
                    newStream.Write(bytes, 0, bytes.Length);
                    newStream.Close();
                    var response = await Task.Run(() => http.GetResponse());
                    var stream = response.GetResponseStream();
                    NavigationService.Navigate(new UsersBankAllInfoPage());
                }
                catch(WebException)
                { MessageBox.Show(" Некорректно введены данные!"); }
            }
            else { MessageBox.Show("Заполните поля!"); }
        }

        private void btCancelChangeBankClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
