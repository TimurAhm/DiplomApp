using AppForDiplomOnApi.EntityESSSS;
using AppForDiplomOnApi.SecurityY;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace AppForDiplomOnApi.WindSSS
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        //private HttpClient HttpClient;
        //  public static string token;
        public static string usersLog;
        public static string usersPass;
        public static string FinalToken;
        public static string WorkerRole;

        public AuthWindow()
        {
            InitializeComponent();
            //    HttpClient = new HttpClient()
            //    {
            //        BaseAddress = new Uri("http://localhost:5000/")
            //    };


        }

        public async void Authorizz()
        {
            try
            {
                usersLog = tbLogin.Text;
                usersPass = tbPassword.Text;
                EntityESSSS.Workers objWorkers = new EntityESSSS.Workers();
                objWorkers.WorkerLogin = tbLogin.Text;
                objWorkers.WorkerPassword = tbPassword.Text;
                string json = JsonConvert.SerializeObject(objWorkers);
                var baseAdress = "http://localhost:5000/token?workername=" + tbLogin.Text + "&password=" +
                    tbPassword.Text;
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

                string tokenResult = new StreamReader(stream, encoding).ReadToEnd();
                string token = String.Empty;
                for (int i = tokenResult.IndexOf("access_token") + 15; i < tokenResult.IndexOf("username") - 3; i++)
                {
                    token += tokenResult[i];
                }
                string userRole = String.Empty;
                for (int i = tokenResult.IndexOf("username") + 11; i < tokenResult.Length -2; i++)
                {
                    userRole += tokenResult[i];
                }
                FinalToken = token;
                WorkerRole = userRole;
               // Debug.WriteLine(userRole);
               // Debug.WriteLine(token);
                MainWindow mainWindow = new MainWindow();
                tbLogin.Clear();
                tbPassword.Clear();
                this.Visibility = Visibility.Hidden;
                mainWindow.ShowDialog();
                this.Visibility = Visibility.Visible;
            }
            catch (WebException)
            {
                MessageBox.Show("Проверьте введенные данные.");
            }
        }


        private void tbLogInApp(object sender, RoutedEventArgs e)
        {
            Authorizz();
            //client.PostAsync("/Token", formContent);

            // var responseJson = await responseMessage.Content.ReadAsStringAsync();
            //var jObject = JObject.Parse(responseJson);
            //JObject jObj = JObject.Parse(parsedContent);
            //string heheheh = jObj.GetValue("access_token").ToString();
            //  string tok = (string)jObj.SelectToken("");
            // string hehe = .GetValue("access_token").ToString();
            //Debug.WriteLine(heheheh);
            //Debug.WriteLine(heheheh);
            //Debug.WriteLine(heheheh);
            //Debug.WriteLine(heheheh);
            //Debug.WriteLine(heheheh);
            //Debug.WriteLine(heheheh);



            //   HttpClient client = new HttpClient();
            //   var baseAdress = "http://localhost:5000/token?username=" + tbLogin.Text + "&password=" + tbPassword.Text;
            //   client.BaseAddress = new Uri(baseAdress);
            //   client.DefaultRequestHeaders.Accept.Clear();
            //   client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            ////   client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            //   var token = GetAPIToken






        }

        private void btQuitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //private static async Task<string> GetAPIToken(string userName, string password)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        //setup client
        //        client.BaseAddress = new Uri(apiBaseUri);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.AccessToken);

        //        //setup login data
        //        var formContent = new FormUrlEncodedContent(new[]
        //         {
        //     new KeyValuePair<string, string>("grant_type", "password"),
        //     new KeyValuePair<string, string>("username", userName),
        //     new KeyValuePair<string, string>("password", password),
        //     });

        //        //send request
        //        HttpResponseMessage responseMessage = await client.PostAsync("/Token", formContent);

        //        //get access token from response body
        //        var responseJson = await responseMessage.Content.ReadAsStringAsync();
        //        var jObject = JObject.Parse(responseJson);
        //        return jObject.GetValue("access_token").ToString();
        //    }
        //}
    }
}
