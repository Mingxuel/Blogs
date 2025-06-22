using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcoMVVM
{
    public partial class BindingMessangerPropertyReceiverViewModel : ObservableObject
    {
        [ObservableProperty]
        private string receiveMessage = "";

        public BindingMessangerPropertyReceiverViewModel()
        {
            WeakReferenceMessenger.Default.Register<PropertyChangedMessage<string>>(this, Receive);
        }

        private void Receive(object recipient, PropertyChangedMessage<string> message)
        {
            ReceiveMessage = message.NewValue;
        }
    }
}
