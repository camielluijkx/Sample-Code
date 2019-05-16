using System;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Popups;
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
        
        Entering a very large number of averages causes the entire user interface to lock up while the program runs the
        event handler behind the "Start" button.

        The button appears to be "stuck down" for the time it takes the event handler to run and interactions with the 
        user interface, for example resizing the application screen, are not possible until the button "pops back up"
        and the answer is displayed.

        */
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            long noOfValues = long.Parse(NumberOfValuesTextBox.Text);
            ResultTextBlock.Text = "Result: " + computeAverages(noOfValues);
        }
    }
}
