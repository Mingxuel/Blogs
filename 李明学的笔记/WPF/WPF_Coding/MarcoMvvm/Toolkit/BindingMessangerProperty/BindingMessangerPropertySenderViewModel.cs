using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcoMVVM
{
    public partial class BindingMessangerPropertySenderViewModel : ObservableObject
    {
        private string sendMessage = "";
        public string SendMessage
        {
            get { return sendMessage; }
            set
            {
                if (SetProperty(ref sendMessage, value))
                {
                    WeakReferenceMessenger.Default.Send(new PropertyChangedMessage<string>(this, nameof(SendMessage), default, value));
                }
            }
        }
    }
}
