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
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Windows.Interop;
namespace HMS
{
    /// <summary>
    /// Interaction logic for dashboard.xaml
    /// </summary>
    public partial class dashboard : Window
    {
        private CustomHttp.MyObject response;


        public dashboard(CustomHttp.MyObject response)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.response = response;

            UserText.Content = response.first_name + " " + response.last_name;
        }

        private void NewForm_Click(object sender, RoutedEventArgs e)
        {
            Form1 form = new Form1();
            WindowInteropHelper wih = new WindowInteropHelper(this);
            wih.Owner = form.Handle;
            form.ShowDialog();
        }

    }
}

