using System;
namespace Lands.ViewsModels
{
    public class MainViewModels
    {
        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModels()
        {
            this.Login = new LoginViewModel();
        }
        #endregion
    }
}
