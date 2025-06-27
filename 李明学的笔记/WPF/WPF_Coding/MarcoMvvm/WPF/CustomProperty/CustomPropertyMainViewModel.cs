using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcoMvvm.WPF.CustomProperty
{
    public partial class CustomPropertyMainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string text = "";

        [RelayCommand]
        private void Click()
        {
            Text = "Hello World";
        }
    }
}
