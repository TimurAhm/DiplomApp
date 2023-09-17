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
using System.Net;
using AppForDiplomOnApi.WindSSS;
using AppForDiplomOnApi.Oops;

namespace AppForDiplomOnApi.PagesS
{
    /// <summary>
    /// Interaction logic for WorkersPage.xaml
    /// </summary>
    public partial class WorkersPage : Page
    {
        public WorkersPage()
        {
            InitializeComponent();
            // GetAllDaaataaa();
            GetOnlyDaaataaa();
        }

        private async void GetAllDaaataaa()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthWindow.FinalToken);
            HttpResponseMessage response = await Task.Run(() => client.GetAsync("api/Worker").Result);
            if (response.IsSuccessStatusCode)
            {
                var workers = response.Content.ReadAsAsync<IEnumerable<Oops.Workers>>().Result;
                
                //.Where(u => u.UserLogin == AuthWindow.usersLog && u.UserPassword == AuthWindow.usersPass)
                //   var users = response.Content.ReadAsStringAsync().Result;
                //  var users = response.Content.ReadAsAsync<EntityESSSS.Users>
                //    var s = Newtonsoft.Json.JsonConvert.DeserializeObject(users);
                // var s = Newtonsoft.Json.JsonConvert.;
                //MessageBox.Show(s.ToString());
                //  MessageBox.Show(users.ToString());
                lvWorkers.ItemsSource = workers;
            }
            else
            {
                MessageBox.Show("Error code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }
        private async void GetOnlyDaaataaa()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthWindow.FinalToken);
            HttpResponseMessage response = await Task.Run(() => client.GetAsync("getworker").Result);
            if (response.IsSuccessStatusCode)
            {
                var workers = response.Content.ReadAsAsync<Oops.Workers>().Result;
                lvWorkers.ItemsSource = Enumerable.Repeat(workers, 1);
                
                // var qwe = workers.WorkerFam; ----------------!!!!!!!!!!!! ДОСТАНЬ РОЛЬ



                //.Where(u => u.UserLogin == AuthWindow.usersLog && u.UserPassword == AuthWindow.usersPass)
                //   var users = response.Content.ReadAsStringAsync().Result;
                //  var users = response.Content.ReadAsAsync<EntityESSSS.Users>
                //    var s = Newtonsoft.Json.JsonConvert.DeserializeObject(users);
                // var s = Newtonsoft.Json.JsonConvert.;
                //MessageBox.Show(s.ToString());
                //  MessageBox.Show(users.ToString());

             //   MessageBox.Show(qwe.ToString());    
                //lvWorkers.ItemsSource = workers;
            }
            else
            {
                MessageBox.Show("Error code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void tbSearchTextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btAddWorkerClick(object sender, RoutedEventArgs e)
        {

        }

        private void btRemakeWorkerClick(object sender, RoutedEventArgs e)
        {

        }

        private void btDeleteWorkerClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
