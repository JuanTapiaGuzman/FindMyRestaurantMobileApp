using FindMyRestaurantAppCP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FindMyRestaurantAppCP.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        public ICommand IngresarCommand { get; private set; }
        public ICommand BackActionCommand { get; private set; }

        public LoginViewModel()
        {
                IngresarCommand = new Command(Ingresar);
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetObservableProperty(ref _userName, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetObservableProperty(ref _password, value); }
        }

        public async void Ingresar()
        {
            bool valido = await AuthenticationProvider.Instance.Login(UserName, Password);

            if(valido)
            {
                
            }
            else
            {
                
            }
        }
    }
}
