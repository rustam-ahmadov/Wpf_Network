using Client.Services;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace Client.ViewModel
{
    class MainViewModel
    {
        public MainViewModel(INetworkService NS)
        {
            networkService = NS;
        }
        private readonly INetworkService networkService;

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
            }
        }

        private RelayCommand _logIn;
        public RelayCommand LogIn => _logIn ??= new(
             () => MessageBox.Show("LogIn Command"),
             () => true
             );

        private RelayCommand _signUp;
        public RelayCommand SignUp => _signUp ??= new(
            () => MessageBox.Show("SignUp Command"),
            () => true);

    }
}
