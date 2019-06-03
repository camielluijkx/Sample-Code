using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace PageViewer
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

        async Task<string> readWebpage(string uri)
        {
            WebClient client = new WebClient();
            return await client.DownloadStringTaskAsync(uri);
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            string webText = await readWebpage(PageUriTextBox.Text);

            ResultTextBlock.Text = webText;
        }
    }
}