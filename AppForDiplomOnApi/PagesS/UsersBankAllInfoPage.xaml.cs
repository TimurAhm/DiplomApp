using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
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
using AppForDiplomOnApi.WindSSS;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace AppForDiplomOnApi.PagesS
{
    /// <summary>
    /// Interaction logic for UsersBankAllInfoPage.xaml
    /// </summary>
    public partial class UsersBankAllInfoPage : Page
    {
        public UsersBankAllInfoPage()
        {
            InitializeComponent();
            GetDaaataaa();

        }

        private async void GetDaaataaa()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthWindow.FinalToken);
            HttpResponseMessage response = await Task.Run(() => client.GetAsync("api/UsersBank").Result);

            if (response.IsSuccessStatusCode)
            {
                var credits = response.Content.ReadAsAsync<IEnumerable<Oops.UsersBanks>>().Result;
                lvUsersBank.ItemsSource = credits.Where(p => p.UsersBankRef.Contains(tbSearch.Text) || p.Valuta.Contains(tbSearch.Text) || Convert.ToString(p.UsersBankBalance).Contains(tbSearch.Text));
            }
            else
            {
                MessageBox.Show("Error code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void btAddBankClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserBankAddPage());
        }

        private void btRemakeBankClick(object sender, RoutedEventArgs e)
        {
            if (lvUsersBank.SelectedValue != null)
            {
                Oops.UsersBanks bankSelect = (Oops.UsersBanks)lvUsersBank.SelectedItem;
                NavigationService.Navigate(new UserBankChangePage(bankSelect));
            }
            else { MessageBox.Show("Выберите данные для изменения."); }
        }

        private void btDeleteBankClick(object sender, RoutedEventArgs e)
        {
            if (lvUsersBank.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Удалить информацию о счете?", "Удалить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Oops.UsersBanks bankSelect = (Oops.UsersBanks)lvUsersBank.SelectedItem;
                    Oops.UsersBanks objProduct = new Oops.UsersBanks();
                    string json = JsonConvert.SerializeObject(objProduct);
                    var baseAddress = "http://localhost:5000/api/UsersBank/" + bankSelect.UsersBankRef + "";
                    var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
                    http.Accept = "application/json";
                    http.ContentType = "application/json";
                    http.Method = "DELETE";
                    string parsedContent = json;
                    UTF8Encoding encoding = new UTF8Encoding();
                    Byte[] bytes = encoding.GetBytes(parsedContent);
                    Stream newStream = http.GetRequestStream();
                    newStream.Write(bytes, 0, bytes.Length);
                    newStream.Close();
                    var response = http.GetResponse();
                    var stream = response.GetResponseStream();
                    GetDaaataaa();
                }
            }
            else { MessageBox.Show("Выберите данные для удаления."); }
        }

        private void tbSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            GetDaaataaa();
        }
    }
}
