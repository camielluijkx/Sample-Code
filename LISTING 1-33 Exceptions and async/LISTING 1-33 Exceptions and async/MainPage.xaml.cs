using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Net.Http;
using System.Threading.Tasks;
using System;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Webpage_Viewer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        static async Task<string> FetchWebPage(string url)
        {
            HttpClient _httpClient = new HttpClient();
            return await _httpClient.GetStringAsync(url);
        }

        /*
        
        It is very important to note that exceptions can only be caught in this way because the FetchWebPage method 
        returns a result; the text of the web page.

        It is possible to create an async method of type void that does not return a value.

        These are to be avoided as there is no way of catching any exceptions that they generate.
        
        The only async void methods that a program should contain are the event handlers themselves.

        Even a method that just performs an action should return a status value so that exceptions can be caught and 
        dealt with.

        */
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ResultTextBlock.Text = await FetchWebPage(URLTextBox.Text);
                StatusTextBlock.Text = "Page Loaded";
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = ex.Message;
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
        }
    }
}