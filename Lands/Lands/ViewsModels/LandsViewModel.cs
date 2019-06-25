
namespace Lands.ViewsModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Services;
    using Xamarin.Forms;

    public class LandsViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes

        private ObservableCollection<Land> lands;

        private bool isRefrehing;

        private string filter;

        private List<Land> landsList;


        #endregion

        #region Properties

        public ObservableCollection<Land> Lands
        {
            get
            {
                return this.lands;
            }
            set
            {
                SetValue(ref this.lands, value);
            }

        }

        public bool IsRefrehing
        {
            get
            {
                return this.isRefrehing;
            }
            set
            {
                SetValue(ref this.isRefrehing, value);
            }

        }

        public string Filter
        {
            get
            {
                return this.filter;
            }
            set
            {
                SetValue(ref this.filter, value);
            }
        }
        #endregion

        #region Constructor
        public LandsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadLands();

            Debug.Write("aa" + this.lands);
        }

        #endregion

        #region Methods

        private async void LoadLands()
        {
            this.IsRefrehing = true;
            var connection = await this.apiService.CheckConnection();


            if (!connection.IsSuccess) 
            {
                this.IsRefrehing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var response = await this.apiService.GetList<Land>(
                "http://restcountries.eu",
                "/rest",
                "/v2/all");

            if (!response.IsSuccess) {

                this.IsRefrehing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            this.landsList = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<Land>(this.landsList);
            this.IsRefrehing = false;
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.lands = new ObservableCollection<Land>(this.landsList);

            }
            else
            {
                this.Lands = new ObservableCollection<Land>(
                    this.landsList.Where(l => l.Name.ToLower().Contains(this.Filter.ToLower())));


            }
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        { 
            get
            {
                return new RelayCommand(LoadLands);
            
            }
        
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);

            }

        }


       
        #endregion


    }
}
