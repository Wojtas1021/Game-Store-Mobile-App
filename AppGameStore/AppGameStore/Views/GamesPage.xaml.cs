﻿using AppGameStore.ViewModels;
using Xamarin.Forms;

namespace AppGameStore.Views
{
    public partial class GamesPage : ContentPage
    {
        GamesViewModel _viewModel;

        public GamesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new GamesViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}