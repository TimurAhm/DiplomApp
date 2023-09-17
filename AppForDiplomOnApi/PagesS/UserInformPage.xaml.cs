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

namespace AppForDiplomOnApi.PagesS
{
    /// <summary>
    /// Interaction logic for UserInformPage.xaml
    /// </summary>
    public partial class UserInformPage : Page
    {
        Oops.Users users;
        public UserInformPage(Oops.Users users1)
        {
            users = users1;
            InitializeComponent();
            GetDaaataaa();
        }

        private async void GetDaaataaa()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthWindow.FinalToken);
            HttpResponseMessage response = await Task.Run(() => client.GetAsync("api/UserInform").Result);

            if (response.IsSuccessStatusCode)
            {
                var UserInform = response.Content.ReadAsAsync<IEnumerable<Oops.UserInforms>>().Result;
                lvInform.ItemsSource = UserInform.Where(p => p.UserInformUserId == users.UserId.ToString());
            }
            else
            {
                MessageBox.Show("Error code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }
    }
}
