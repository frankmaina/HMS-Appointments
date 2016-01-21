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

            //check if there is internet connection
            //not the most efficient way to do this
            Boolean status = CustomHttp.check_connection();
            if (status)
            {
                connectionStatus.Content = "Connected";
                connectionStatus.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                connectionStatus.Content = "Not Connected";
                connectionStatus.Foreground = new SolidColorBrush(Colors.Red);
            }

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //get input values from input fileds
            try
            {
                String username = usernameTxt.Text;
                String password = passwordTxt.Text;

                //launch authentication request
                /* Basically communicate to the Web server to auhtenticate
                 * the user. */
                CustomHttp.MyObject response = CustomHttp.JsonHttpGet("http://127.0.0.1:8000/api/validate/user?username=" + username + "&password=" + password);

                if (response.result == "OK")
                {
                    //successful login.
                    //we save the credentials here in a local db
                    Window dashboard = new dashboard();
                    dashboard.Show();
                    Window login = new MainWindow();
                    this.Close();

                    
                }
                else
                {
                    MessageBox.Show(response.reason);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());

            }

        }

    }
}