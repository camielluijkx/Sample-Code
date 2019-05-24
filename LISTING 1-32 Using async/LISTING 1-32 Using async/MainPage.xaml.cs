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

        private Task<double> asyncComputeAverages(long noOfValues)
        {
            return Task<double>.Run(() =>
            {
                return computeAverages(noOfValues);
            });
        }

        /*
        
        The StartButton_Click event handler method is marked as async.

        This tells the compiler to treat this method as special.

        It means that the method will contain one or more uses of the await keyword.

        The await keyword represents "a statement of intent" to perform an action.

        The keyword precedes a call of a method that will return the task to be performed.

        The compiler will generate code that will cause the async method to return to the caller at the point the await 
        is reached.

        It will then go on to generate code that will perform the awaited action asynchronously and then continue with
        the body of the async method.
         
        */
        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            long noOfValues = long.Parse(NumberOfValuesTextBox.Text);

            ResultTextBlock.Text = "Calculating";

            double result = await (asyncComputeAverages(noOfValues));

            ResultTextBlock.Text = "Result: " + result.ToString();
        }
    }
}