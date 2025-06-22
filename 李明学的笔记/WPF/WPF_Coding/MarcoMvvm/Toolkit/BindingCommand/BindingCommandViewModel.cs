using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using static System.Net.Mime.MediaTypeNames;

namespace MarcoMVVM
{
    public partial class BindingCommandViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Group1_Out))]
        private string group1_In = "Hello World!";

        public string Group1_Out => $"{Group1_In}";

        [ObservableProperty]
        private string group2_In = "Hello World!";

        public string Group2_Out => $"{Group2_In}";

        partial void OnGroup2_InChanged(string value)
        {
            OnPropertyChanged(nameof(Group2_Out));
        }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SyncClickCommand))]
        [NotifyCanExecuteChangedFor(nameof(AsyncClickCommand))]
        private bool isEnabled = false;

        [RelayCommand(CanExecute =nameof(CanSyncClick))]
        private void SyncClick()
        {
            if (Group1_In == "Goobye World!")
            {
                Group1_In = "Hello World!";
            }
            else
            {
                Group1_In = "Goobye World!";
            }
        }

        [RelayCommand(CanExecute = nameof(CanAsyncClick))]
        private async Task AsyncClick()
        {
            await Task.Delay(2000);
            if (Group2_In == "Goobye World!")
            {
                Group2_In = "Hello World!";
            }
            else
            {
                Group2_In = "Goobye World!";
            }
        }

        private bool CanSyncClick() => IsEnabled;
        private bool CanAsyncClick() => IsEnabled;
    }
}
