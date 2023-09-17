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
using AppForDiplomOnApi.EntityESSSS;
using AppForDiplomOnApi.Oops;
using AppForDiplomOnApi.WindSSS;
using System.Collections.Immutable;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace AppForDiplomOnApi.PagesS
{
    /// <summary>
    /// Interaction logic for UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
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
            HttpResponseMessage response = await Task.Run(() => client.GetAsync("api/Users").Result);
            
            if (response.IsSuccessStatusCode)
            {
                var users = response.Content.ReadAsAsync<IEnumerable<Oops.Users>>().Result;
                lvUsers.ItemsSource = users.Where(p => p.UserName.Contains(tbSearch.Text) || p.UserRole.Contains(tbSearch.Text) || p.UserFam.Contains(tbSearch.Text) || p.UserOtch.Contains(tbSearch.Text) || p.UserBalanceRef.Contains(tbSearch.Text));


                //.Where(u => u.UserLogin == AuthWindow.usersLog && u.UserPassword == AuthWindow.usersPass)
                //   var users = response.Content.ReadAsStringAsync().Result;
                //  var users = response.Content.ReadAsAsync<EntityESSSS.Users>
                //    var s = Newtonsoft.Json.JsonConvert.DeserializeObject(users);
                // var s = Newtonsoft.Json.JsonConvert.;
                //MessageBox.Show(s.ToString());
                //  MessageBox.Show(users.ToString());
            }
            else
            {
                MessageBox.Show("Error code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void btRemakeUserClick(object sender, RoutedEventArgs e)
        {
            if (lvUsers.SelectedValue != null)
            {
                Oops.Users userSelect = (Oops.Users)lvUsers.SelectedItem;
                NavigationService.Navigate(new UsersChangePage(userSelect));
            }
            else { MessageBox.Show("Выберите данные для изменения."); }
        }

        private void btAddUserClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UsersAddPage());
        }

        private void btDeleteUserClick(object sender, RoutedEventArgs e)
        {
            if (lvUsers.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Удалить информацию о клиенте?", "Удалить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Oops.Users userSelect = (Oops.Users)lvUsers.SelectedItem;
                    Oops.Users objProduct = new Oops.Users();
                    string json = JsonConvert.SerializeObject(objProduct);
                    var baseAddress = "http://localhost:5000/api/Users/" + userSelect.UserId + "";
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

        private void btShowUsersCredits(object sender, RoutedEventArgs e)
        {
            Oops.Users users = (sender as Button).DataContext as Oops.Users;
            NavigationService.Navigate(new CreditsPage(users));
        }

        private void btShowCreditsCredits(object sender, RoutedEventArgs e)
        {
            Oops.Users users = (sender as Button).DataContext as Oops.Users;
            NavigationService.Navigate(new UsersBankPage(users));
        }

        private void btShowUserInform(object sender, RoutedEventArgs e)
        {
            Oops.Users users = (sender as Button).DataContext as Oops.Users;
            NavigationService.Navigate(new UserInformPage(users));
        }
    }
}