using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;

namespace MarcoMVVM
{
    public class MainWindowViewModel
    {
        // 数据集合
        public ObservableCollection<string> Items { get; set; }
        public string NewItem { get; set; }

        // 命令属性
        public ICommand AddItemCommand { get; private set; }
        public ICommand ClearItemsCommand { get; private set; }

        public MainWindowViewModel()
        {
            // 初始化数据
            Items = new ObservableCollection<string>();

            // 初始化命令 - 带参数的命令
            AddItemCommand = new RelayCommand(
                parameter => AddItem((string)parameter),  // 执行方法
                parameter => !string.IsNullOrEmpty((string)parameter)  // 可执行判断
            );

            // 初始化命令 - 无参数的命令
            ClearItemsCommand = new RelayCommand(
                parameter => ClearItems(),
                parameter => Items.Count > 0
            );
        }

        private void AddItem(string item)
        {
            Items.Add(item);
            NewItem = string.Empty; // 清空输入框
        }

        private void ClearItems()
        {
            if (MessageBox.Show("确定要清空列表吗？", "确认",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Items.Clear();
            }
        }
    }
}
