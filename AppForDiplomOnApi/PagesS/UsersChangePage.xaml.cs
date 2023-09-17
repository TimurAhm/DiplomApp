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
    /// Interaction logic for UsersChangePage.xaml
    /// </summary>
    public partial class UsersChangePage : Page
    {
        Oops.Users users1;
        public UsersChangePage(Oops.Users users)
        {
            this.users1 = users;
            InitializeComponent();
            DataContext = users1;
        }


        private void btSaveChangeClick(object sender, RoutedEventArgs e)
        {
            SaveEditUser();
        }

        private void btDeleteClick(object sender, RoutedEventArgs e)
        {

        }

        private async void SaveEditUser()
        {
            if (tbUserIdP != null && tbUserFamP != null && tbUserNameP != null && tbUserBalanceP != null &&
                tbUserRoleP != null && tbUserLoginP != null)
            {
                try
                {
                    Oops.Users objUserss = new Oops.Users();
                    //  int a = Convert.ToString(tbUserIdP.Text);
                    objUserss.UserId = tbUserIdP.Text;
                    objUserss.UserFam = tbUserFamP.Text;
                    objUserss.UserName = tbUserNameP.Text;
                    objUserss.UserOtch = tbUserOtchP.Text;
                    objUserss.UserBalanceRef = tbUserBalanceP.Text;
                    objUserss.UserRole = tbUserRoleP.Text;
                    objUserss.UserLogin = tbUserLoginP.Text;
                    string json = JsonConvert.SerializeObject(objUserss);
                    var baseAdress = "http://localhost:5000/api/Users/PutUser?IdUUSSEERR=" + tbUserIdP.Text + "&UserFam=" + tbUserFamP.Text + "&UserName=" +
                        tbUserNameP.Text + "&UserOtch=" + tbUserOtchP.Text + "&UserBalanceRef=" + tbUserBalanceP.Text + "&UserRole=" + tbUserRoleP.Text
                        + "&UserLogin=" + tbUserLoginP.Text;
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
                    NavigationService.Navigate(new UsersPage());
                }
                catch (WebException)
                { MessageBox.Show("Некорректно введены данные! \n Возможно введен неверный счет"); }
            }
            else { MessageBox.Show("Заполните поля!"); }
        }

        private void btCancelChangeClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
