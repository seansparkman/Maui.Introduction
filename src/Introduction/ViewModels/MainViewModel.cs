using CommunityToolkit.Mvvm.ComponentModel;
using Introduction.Services;
using Refit;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Contact = Introduction.Models.Contact;

namespace Introduction.ViewModels
{
    public sealed class MainViewModel : ObservableObject
    {
        private IRandomUser UserApi { get; }

        public ICommand LoadCommand { get; }

        public ObservableCollection<Contact> Contacts { get; } = new ();

        public MainViewModel()
        {
            UserApi = RestService.For<IRandomUser>(
                "https://randomuser.me",
                new RefitSettings(new NewtonsoftJsonContentSerializer()));

            LoadCommand = new AsyncRelayCommand(Load);
        }

        private async Task Load()
        {
            try
            {
                var response = await UserApi.GetUsers("northdallas");
                
                response.Results.ForEach(Contacts.Add);
            }
            catch (ApiException apiException)
            {
                Console.WriteLine(apiException.Message);
                Debugger.Break();
            }

        }
    }
}
