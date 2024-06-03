using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;

namespace WeekendPlanner_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        API_Service api=API_Service.Instance;

        public MainWindow()
        {
            InitializeComponent(); 
        }

        private async void onLoad(object sender, RoutedEventArgs e)
        {
            List<Event> tmp=await api.GetEvents();
            foreach (Event eve in tmp) 
            {
                wrapPanel.Children.Add(createEventSmall(eve));
            }
        }

        private Border createEventSmall(Event e)
        {
            Label name = new Label
            {
                Content = e.Name,
                FontWeight = FontWeights.Bold,
            };

            Label date = new Label
            {
                Content = e.Start
            };

            Label location = new Label
            {
                Content = e.Location
            };

            StackPanel stackPanel=new StackPanel();

            stackPanel.Children.Add(name);
            stackPanel.Children.Add(date);
            stackPanel.Children.Add(location);

            Border tmp = new Border
            {
                CornerRadius=new CornerRadius(25),
                BorderBrush=new SolidColorBrush((Color) ColorConverter.ConvertFromString("#D8BFD8")),
                BorderThickness =new Thickness(3),
                Margin=new Thickness(10),
                Padding=new Thickness(5),
                Background=new SolidColorBrush((Color) ColorConverter.ConvertFromString("#98FF98"))

            };
            

            tmp.Child = stackPanel;

            return tmp;
        }

        private void Test(object sender, EventArgs e)
        {
            MessageBox.Show("Hello!");
        }
    }
}