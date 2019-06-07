using System;


namespace Lands.ViewsModels
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Lands.Views;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
      
        #region Attributes

        private string password;
        private bool isRunning;
        private bool isEnable;
        private string email;

        #endregion

        #region Properties
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                SetValue(ref this.email, value);
            }

        }

        public string Password
        {
            get 
            {
                return this.password;
            }
            set 
            {
                SetValue(ref this.password, value);
            }
        }

        public bool IsRunning
        {
            get
            {
                return this.isRunning;
            }
            set
            {
                SetValue(ref this.isRunning, value);
            }
        }

        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnable
        {
            get
            {
                return this.isEnable;
            }
            set
            {
                SetValue(ref this.isEnable, value);
            }
        }
        #endregion

        #region Commands

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        #endregion

        #region Constructor
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnable = true;
            this.Email = "seosori@bancolombia.com.co";
            this.Password = "1234";

        }



        private async void Login()
        {
            if(string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email.",
                    "Accept");
                return;

            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a password.",
                    "Accept");
                this.Password = string.Empty;
                return;
            }

            if(this.Email != "seosori@bancolombia.com.co" || this.Password != "1234")
            {
                this.IsRunning = false;
                this.IsEnable = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or password incorrec",
                    "Accept");
                this.Password = string.Empty;
                return;

            }

            this.IsRunning = false;
            this.IsEnable = true;
            this.Email = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());

        }
        #endregion
    }
}
