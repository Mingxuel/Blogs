using System.Configuration;
using System.Reflection;
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

namespace MarcoMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> manual_buttons = new List<string>() { 
            "UC_BindingManualCommand", 
            "UC_BindingManualData", 
            "UC_BindingStatic" , 
            "UC_BindingAnotherControl", 
            "UC_BindingRelativeSource", 
            "UC_BindingManualCollection",
            "UC_BindingManualConverter",
            "UC_BindingManualMultiConverter",
            "UC_BindingManualValidationRule",
            "UC_BindingEventCommand",
        };

        List<string> toolkit_buttons = new List<string>() {
            "UC_BindingData",
            "UC_BindingCommand",
            "UC_BindingMessanger",
            "UC_BindingMessangerProperty",
            "UC_BindingMessangerRequest",
            "UC_Validation",
            "UC_JsonSerializer",
            "UC_TaskObject",
        };

        public MainWindow()
        {
            InitializeComponent();

            foreach(string button in manual_buttons)
            {
                Button bt = new Button();
                bt.Content = button;
                bt.Width = 218;
                bt.Height = 40;
                bt.Click += ManualButtonClick;
                ManualButtonPool.Children.Add(bt);
            }

            foreach (string button in toolkit_buttons)
            {
                Button bt = new Button();
                bt.Content = button;
                bt.Width = 218;
                bt.Height = 40;
                bt.Click += ManualButtonClick;
                ToolkitButtonPool.Children.Add(bt);
            }
        }

        private void ManualButtonClick(object sender, RoutedEventArgs e)
        {
            WindowPool.Children.Clear();
            string uc = ((Button)sender).Content.ToString();
            switch (uc)
            {
                case "UC_BindingManualCommand":
                    WindowPool.Children.Add(new UC_BindingManualCommand());
                    return;
                case "UC_BindingManualData":
                    WindowPool.Children.Add(new UC_BindingManualData());
                    return;
                case "UC_BindingStatic":
                    WindowPool.Children.Add(new UC_BindingStatic());
                    return;
                case "UC_BindingAnotherControl":
                    WindowPool.Children.Add(new UC_BindingAnotherControl());
                    return;
                case "UC_BindingRelativeSource":
                    WindowPool.Children.Add(new UC_BindingRelativeSource());
                    return;
                case "UC_BindingManualCollection":
                    WindowPool.Children.Add(new UC_BindingManualCollection());
                    return;
                case "UC_BindingManualConverter":
                    WindowPool.Children.Add(new UC_BindingManualConverter());
                    return;
                case "UC_BindingManualMultiConverter":
                    WindowPool.Children.Add(new UC_BindingManualMultiConverter());
                    return;
                case "UC_BindingManualValidationRule":
                    WindowPool.Children.Add(new UC_BindingManualValidationRule());
                    return;
                case "UC_BindingEventCommand":
                    WindowPool.Children.Add(new UC_BindingEventCommand());
                    return;
                case "UC_BindingData":
                    WindowPool.Children.Add(new UC_BindingData());
                    return;
                case "UC_BindingCommand":
                    WindowPool.Children.Add(new UC_BindingCommand());
                    return;
                case "UC_BindingMessanger":
                    WindowPool.Children.Add(new UC_BindingMessanger());
                    return;
                case "UC_BindingMessangerProperty":
                    WindowPool.Children.Add(new UC_BindingMessangerProperty());
                    return;
                case "UC_BindingMessangerRequest":
                    WindowPool.Children.Add(new UC_BindingMessangerRequest());
                    return;
                case "UC_Validation":
                    WindowPool.Children.Add(new UC_Validation());
                    return;
                case "UC_JsonSerializer":
                    WindowPool.Children.Add(new UC_JsonSerializer());
                    return;
                case "UC_TaskObject":
                    WindowPool.Children.Add(new UC_TaskObject());
                    return;
            }
        }
    }
}