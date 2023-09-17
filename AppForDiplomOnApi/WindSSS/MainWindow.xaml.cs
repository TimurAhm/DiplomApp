using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Json;
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
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Windows.Media.Animation;
using AppForDiplomOnApi.PagesS;
using AppForDiplomOnApi.EntityESSSS;
using AppForDiplomOnApi.WindSSS;

namespace AppForDiplomOnApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // Users users1;
        public MainWindow()
        {
           // this.users1 = users;
            InitializeComponent();
            if (AuthWindow.WorkerRole == "User")
            {
                btAllWorkers.Visibility = Visibility.Collapsed;
                
            }
            
           // DataContext = users1;
            //MessageBox.Show(users1.UserLogin.ToString());

            // GetDaaataaa();
            //dgvhehe.ItemsSource = GetDataaaa
        }

        //  private async void GetDataaaa(List<Users> usersSSS)
        //  {
        //using (HttpClient client = new HttpClient())
        //{
        //    client.BaseAddress = new Uri("http://localhost:5000/api/");
        //    //HTTP GET
        //    var responceTask = client.GetAsync("Users");
        //    responceTask.Wait();

        //    var result = responceTask.Result;
        //    if (result.IsSuccessStatusCode)
        //    {
        //        var readTask = result.Content.ReadAsAsync<Users>();
        //        readTask.Wait();
        //        return usersSSS = readTask.Result;

        //        //var users = readTask.Result.ToList() ;


        //        //foreach (var Users in users)
        //        //{
        //        //message.Content = Users;
        //        //}
        //    }

        //var response = await client.GetAsync("http://localhost:5000/api/Users");
        //response.EnsureSuccessStatusCode();
        //if (response.IsSuccessStatusCode)
        //{
        //    message.Content = await response.Content.ReadAsStringAsync();
        //}
        //else
        //{
        //    message.Content = $"Server error code {response.StatusCode}";
        //}
        //  }

        
        


        private async void btHehClick(object sender, RoutedEventArgs e)
        {

        }

        private void btAddClick(object sender, RoutedEventArgs e)
        {

            
           // GetDaaataaa();
        }




        private void btAddClickP(object sender, RoutedEventArgs e)
        {
            //Users users = (Users)lvUsers.SelectedItem as Users;
           
           // GetDaaataaa();
        }

        private void btDeleteClick(object sender, RoutedEventArgs e)
        {
            //Oops.Users objUsersDel = new Oops.Users();
            //objUsersDel.UserId = tbUserIdP.Text;
            //string json = JsonConvert.SerializeObject(objUsersDel);
            //var baseAddress = "http://localhost:5000/api/Users/" + tbUserIdP.Text + "";
            //var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
            //http.Accept = "application/json";
            //http.ContentType = "application/json";
            //http.Method = "DELETE";
            //string parsedContent = json;
            //UTF8Encoding encoding = new UTF8Encoding();
            //Byte[] bytes = encoding.GetBytes(parsedContent);
            //Stream newStream = http.GetRequestStream();
            //newStream.Write(bytes, 0, bytes.Length);
            //newStream.Close();
            //var response = http.GetResponse();
            //var stream = response.GetResponseStream();
            //GetDaaataaa();
        }

        private void btUpdateUsersClick(object sender, RoutedEventArgs e)
        {
            FrNav.Navigate(new UsersPage());
        }

        private void btUpdateWorkersClick(object sender, RoutedEventArgs e)
        {
            FrNav.Navigate(new WorkersPage());
        }

        private void btUpdateCreditsClick(object sender, RoutedEventArgs e)
        {
            FrNav.Navigate(new CreditsAllInfoPage());
        }

        private void btUpdateUsersBankClick(object sender, RoutedEventArgs e)
        {
            FrNav.Navigate(new UsersBankAllInfoPage());
        }

        private void btWorkersClick(object sender, RoutedEventArgs e)
        {
            FrNav.Navigate(new WorkersAllPage());
        }

        private void btUsersInfoClick(object sender, RoutedEventArgs e)
        {
            FrNav.Navigate(new UsernformAllDataPage());
        }

        private void btCloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
