using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for WorkerChangePage.xaml
    /// </summary>
    public partial class WorkerChangePage : Page
    {
        Oops.Workers workers1;
        public WorkerChangePage(Oops.Workers workers)
        {
            this.workers1 = workers;
            InitializeComponent();
            DataContext = workers1;
        }
    }
}
