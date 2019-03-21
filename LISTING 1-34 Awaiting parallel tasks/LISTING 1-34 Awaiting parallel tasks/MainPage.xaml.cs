using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

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

        static async Task<IEnumerable<string>> FetchWebPages(string[] urls)
        {
            var tasks = new List<Task<String>>();

            foreach (string url in urls)
            {
                tasks.Add(FetchWebPage(url));
            }

            return await Task.WhenAll(tasks);
        }

        /*
        
        An async method can contain a number of awaited actions which will be completed in sequence.

        You can use the Task.WhenAll method to create an "awaitable" task that returns when a number of parallel tasks 
        have completed.

        The Task.enAll method is given a list of tasks and returns a collection which contains their results when they 
        have completed.

        There is also a WhenAny method that will return when any one of the given tasks completes.

        */
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] names = URLTextBox.Text.Split(new char[] { ',' });

                var pages = await FetchWebPages(names);

                string fullText = "";

                foreach (string page in pages)
                {
                    fullText += page;
                }
                ResultTextBlock.Text = fullText;

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
