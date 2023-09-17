using AppForDiplomOnApi.WindSSS;
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

namespace AppForDiplomOnApi.PagesS
{
    /// <summary>
    /// Interaction logic for WorkersAllPage.xaml
    /// </summary>
    public partial class WorkersAllPage : Page
    {
        public WorkersAllPage()
        {
            InitializeComponent();
            GetAllDaaataaa();
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
                lvWorkers.ItemsSource = workers.Where(p => p.WorkerFam.Contains(tbSearch.Text) || p.WorkerRole.Contains(tbSearch.Text));
            }
            else
            {
                MessageBox.Show("Срок сессии окончен, перезапустите программу.");
              //  MessageBox.Show("Error code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void tbSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            GetAllDaaataaa();
        }

        private void btAddWorkerClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WorkerAddPage());
        }

        private void btRemakeWorkerClick(object sender, RoutedEventArgs e)
        {
            Oops.Workers workers = (Oops.Workers)lvWorkers.SelectedItem as Oops.Workers;
            NavigationService.Navigate(new WorkerChangePage(workers));
        }

        private void btDeleteWorkerClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
