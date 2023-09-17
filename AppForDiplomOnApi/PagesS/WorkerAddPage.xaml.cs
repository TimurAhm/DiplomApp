using Microsoft.Win32;
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
    /// Interaction logic for WorkerAddPage.xaml
    /// </summary>
    public partial class WorkerAddPage : Page
    {
        public WorkerAddPage()
        {
            InitializeComponent();
        }

        public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }

        private async void SaveUser()
        {
            EntityESSSS.Workers objWorkers = new EntityESSSS.Workers();
            objWorkers.WorkerFam = tbWorkerFam.Text;
            objWorkers.WorkerName = tbWorkerName.Text;
            objWorkers.WorkerOtch = tbWorkerOtch.Text;
            objWorkers.WorkerLogin = tbWorkerLogin.Text;
            objWorkers.WorkerPassword = tbWorkerPassword.Text;
            objWorkers.WorkerRole = tbWorkerRole.Text;
            objWorkers.WorkerPicture = getJPGFromImageControl(iWorkerImage.Source as BitmapImage);
            string json = JsonConvert.SerializeObject(objWorkers);
            var baseAdress = "http://localhost:5000/api/Worker/PostWorker?WorkerFam=" + tbWorkerFam.Text + "&WorkerName=" +
               tbWorkerName.Text + "&WorkerOtch=" + tbWorkerOtch.Text + "&WorkerLogin=" + tbWorkerLogin.Text + "&WorkerPassword=" + tbWorkerPassword.Text
                + "&WorkerPicture=" + objWorkers.WorkerPicture + "&WorkerRole=" + tbWorkerRole.Text;
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
            NavigationService.Navigate(new WorkersAllPage());
        }

        private void ImageClick(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "*Jpeg images|*.jpg|All files|*.*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                var Readactedimg = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void btSaveAddClick(object sender, RoutedEventArgs e)
        {
            SaveUser();
        }
    }
}
