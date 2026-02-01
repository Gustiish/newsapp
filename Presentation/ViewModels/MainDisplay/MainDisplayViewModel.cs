
using Domain.DTOs;
using Presentation.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Presentation.ViewModels.MainDisplay
{
    public class MainDisplayViewModel : BaseViewModel
    {
        private readonly ApplicationState _currentState;
        private bool _hasRemainingArticles;
        private Visibility _isVisible;
        public Visibility IsVisible
        {
            get => _isVisible; set
            {
                _isVisible = value;
                NotifyPropertyChanged(nameof(IsVisible));
            }

        }


        private ObservableCollection<ArticleDTO> _articles;
        public ObservableCollection<ArticleDTO> Articles
        {
            get => _articles;
            set
            {
                _articles = value;
                NotifyPropertyChanged(nameof(Articles));
            }
        }

        public ICommand GetDetails { get; }
        public ICommand GetNextPage { get;}
        public ICommand GetPreviousPage { get; }



        public MainDisplayViewModel(ApplicationState state)
        {
            _currentState = state;
            _articles = new ObservableCollection<ArticleDTO>();

            _currentState.StateChanged += this.OnStateChanged;

            GetDetails = new RelayCommandAsync<ArticleDTO>(GoToDetails);
            GetNextPage = new RelayCommandAsync(LoadNextPage);
            GetPreviousPage = new RelayCommandAsync(LoadPreviousPage);
            _hasRemainingArticles = true;
        }

        private async void OnStateChanged(object? sender, EventArgs e)
        {
            _hasRemainingArticles = true;
            await ApplyFilters();
        }



        private async Task GoToDetails(ArticleDTO article)
        {

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"article",  article}
            };

            await Shell.Current.GoToAsync("//ArticleDetails", parameters);
        }

        private async Task LoadPreviousPage()
        {
            if (_currentState.CurrentFilter.Page == 1)
                return;

            _currentState.CurrentFilter.Page--;
            await ApplyFilters();
        }

        private async Task LoadNextPage()
        {
            _currentState.CurrentFilter.Page++;
            await ApplyFilters();
        }
        public async Task ApplyFilters()
        {
            var result = await _currentState.LoadArticles();
            Articles.Clear();
            foreach (var item in result)
                Articles.Add(item);

        }



    }
}
