using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyDream
{
    /// <summary>
    /// Board.xaml 的交互逻辑
    /// </summary>
    public partial class Board : UserControl
    {
        public Board()
        {
            InitializeComponent();

            this.DataContext = new BoardViewModel();
        }
    }
}
