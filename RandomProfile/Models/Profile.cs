using System;

using Newtonsoft.Json;
using System.ComponentModel;

namespace RandomProfileApp.Models
{
    public class Profile : INotifyPropertyChanged
    {
        public Uri Picture { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }

        public string Serialize() => JsonConvert.SerializeObject(this);
        public static Profile Deserialize(string json) => JsonConvert.DeserializeObject<Profile>(json);

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
