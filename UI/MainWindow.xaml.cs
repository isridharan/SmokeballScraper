using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
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

namespace UI
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

        private async void btnHits_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    lblCountValue.Content = "";
                    lblProcessing.Visibility = Visibility.Visible;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
                    client.DefaultRequestHeaders.Accept.Clear();
                    var _uri = ConfigurationManager.AppSettings["scrapperAPIUri"];
                    var querystring = "/search?searchcontent=" + txtSearchStringValue.Text + "&" + "url=" + txtSearchUrlValue.Text;
                    var response = await client.GetAsync(_uri + querystring);
                    if (response.IsSuccessStatusCode)
                    {
                        lblProcessing.Visibility = Visibility.Hidden;
                        lblCountValue.Content = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {

                        var content = await response.Content.ReadAsStringAsync();
                        lblProcessing.Visibility = Visibility.Hidden;
                        MessageBox.Show(content,"Error Occured", MessageBoxButton.OK, MessageBoxImage.Error);                       
                    }
                }
                catch (Exception ex)
                {
                    lblProcessing.Visibility = Visibility.Hidden;
                    MessageBox.Show("Error Occured while fetching the data" + ex.Message, "Error Occured", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void btnReset_Click(object sender, RoutedEventArgs e)
        {            
            lblCountValue.Content = "";            
            txtSearchUrlValue.Text = "";
            txtSearchStringValue.Text = "";
            lblProcessing.Visibility = Visibility.Hidden;
        }

    }
}
