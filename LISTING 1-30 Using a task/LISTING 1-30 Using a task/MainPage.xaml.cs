using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Random_Averages
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

        private double computeAverages(long noOfValues)
        {
            double total = 0;
            Random rand = new Random();

            for (long values = 0; values < noOfValues; values++)
            {
                total = total + rand.NextDouble();
            }

            return total / noOfValues;
        }

        /*
        
        The idea behind this code is that the action of the button press starts a task running that completes in the 
        background.

        This means that the button does not appear to "stick down" and lock up the user interface.

        This code is correct from a task management point of view, but it will fail when it runs.

        This is because interaction with display components is strictly managed by the process that generates the 
        display.

        A background task cannot simply set the properties of a display element; instead it must follow a particular
        protocol to achieve the required update.
       
        */
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            long noOfValues = long.Parse(NumberOfValuesTextBox.Text);
            Task.Run(() =>
            {
                // System.Exception: 'The application called an interface that was marshalled for a different thread. 
                // (Exception from HRESULT: 0x8001010E (RPC_E_WRONG_THREAD))'
                ResultTextBlock.Text = "Result: " + computeAverages(noOfValues);
            });
        }
    }
}
