using System;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PageViewer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        async Task<string> readWebpage(string uri)
        {
            HttpClient client = new HttpClient();
            return await client.GetStringAsync(uri);
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string webText = await readWebpage(PageUriTextBox.Text);
                ResultTextBlock.Text = webText;
            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog(ex.Message, "Request failed");
                await dialog.ShowAsync();
            }
        }
    }
}