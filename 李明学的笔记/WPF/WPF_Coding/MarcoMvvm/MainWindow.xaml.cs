using MarcoMvvm.Manual;
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
        List<string> buttons = new List<string>() { 
            "UC_BindingManualCommand", 
            "UC_BindingManualData", 
            "UC_BindingStatic" , 
            "UC_BindingAnotherControl", 
            "UC_BindingRelativeSource", 
            "UC_BindingManualCollection",
            "UC_BindingManualConverter",
            "UC_BindingManualMultiConverter"
        };

        public MainWindow()
        {
            InitializeComponent();

            foreach(string button in buttons)
            {
                Button bt = new Button();
                bt.Content = button;
                bt.Width = 180;
                bt.Height = 40;
                bt.Click += Bt_Click;
                ButtonPool.Children.Add(bt);
            }
        }

        private void Bt_Click(object sender, RoutedEventArgs e)
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
            }
        }
    }
}