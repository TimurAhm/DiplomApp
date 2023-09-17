using AppForDiplomOnApi.WindSSS;
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
    /// Interaction logic for UsersAddPage.xaml
    /// </summary>
    public partial class UsersAddPage : Page
    {
        public UsersAddPage()
        {
            InitializeComponent();
        }

        private void btSaveAddClick(object sender, RoutedEventArgs e)
        {
            SaveUser();
        }

        private async void SaveUser()
        {
            try
            {
                EntityESSSS.Users objUsers = new EntityESSSS.Users();
                objUsers.UserFam = tbUserFam.Text;
                objUsers.UserName = tbUserName.Text;
                objUsers.UserOtch = tbUserOtch.Text;
                objUsers.UserBalanceRef = tbUserBalance.Text;
                objUsers.UserRole = tbUserRole.Text;
                objUsers.UserLogin = tbUserLogin.Text;
                string json = JsonConvert.SerializeObject(objUsers);
                var baseAdress = "http://localhost:5000/api/Users/PostUser?UserFam=" + tbUserFam.Text + "&UserName=" +
                    tbUserName.Text + "&UserOtch=" + tbUserOtch.Text + "&UserBalanceRef=" + tbUserBalance.Text + "&UserRole=" + tbUserRole.Text
                    + "&UserLogin=" + tbUserLogin.Text;
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
                NavigationService.Navigate(new UsersPage());
            }
            catch (WebException)
            { MessageBox.Show(" Некорректно введены данные! \n Возможно введен неверный счет."); }
        }

        private void btCancelAddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
