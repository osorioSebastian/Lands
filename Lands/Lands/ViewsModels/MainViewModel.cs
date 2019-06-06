﻿using System;
namespace Lands.ViewsModels
{
    public class MainViewModel
    {
        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }

        public LandsViewModel Lands
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            this.Login = new LoginViewModel();
        }
        #endregion

        #region Single ton

        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        { 
            if(instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }

        #endregion
    }
}
