using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarcoMVVM
{
    public partial class User : ObservableObject
    {
        [ObservableProperty]
        [property: JsonPropertyName("FullName")]
        public string name;

        [ObservableProperty]
        public string age;

        [ObservableProperty]
        [property: JsonIgnore]
        public string password;
    }
}
