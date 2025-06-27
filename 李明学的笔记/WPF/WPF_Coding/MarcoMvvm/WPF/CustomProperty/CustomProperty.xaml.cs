using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// CustomProperty.xaml 的交互逻辑
    /// </summary>
    public partial class CustomProperty : UserControl
    {
        public CustomProperty()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public static readonly DependencyProperty CustomTextProperty = DependencyProperty.Register(nameof(CustomText), typeof(bool), typeof(CustomProperty), new PropertyMetadata(false, null));

        public string CustomText
        {
            get => (string)GetValue(CustomTextProperty);
            set => SetValue(CustomTextProperty, value);
        }
    }
}
