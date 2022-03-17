using Client.Services;
using CommunityToolkit.Mvvm.Input;
using Shared.Models;
using Shared.Tools;
using System.Windows;

namespace Client.ViewModel
{
    class MainViewModel
    {
        private readonly INetworkService networkService;
        private Request request;
        public string Name { get; set; }
        public string Password { get; set; }
        public MainViewModel(INetworkService NS)
        {
            networkService = NS;
        }

        private RelayCommand _logIn;
        public RelayCommand LogIn => _logIn ??= new(

             () =>
             {
                 if (IsRequestAssign())
                     networkService.SendCredentialsToServerAsync(request);
             }
             ,
             delegate { return true; }
        );

        private RelayCommand _signUp;
        public RelayCommand SignUp => _signUp ??= new(

            () =>
            {
                if (IsRequestAssign())
                    networkService.SendCredentialsToServerAsync(request);
            }
            ,
            delegate { return true; }
        );

        private bool IsRequestAssign()
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Password))
            {
                var userCredentials = new UserCredentials(Name, Password);
                request = new Request(userCredentials, requestTypes: RequestTypes.LOGIN);
                return true;
            }
            return false;
        }
    }

}
