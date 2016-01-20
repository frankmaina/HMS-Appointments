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
using System.Threading;


namespace HMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //get input values from input fileds
            try
            {
                String username = usernameTxt.Text;
                String password = passwordTxt.Text;

                //launch authentication request
                CustomHttp.HttpGet("http://www.google.com");

                MessageBox.Show("Done");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());

            }






        }

        

    }
}
