using Domain.DTOs;
using Domain.Filters;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Presentation.ViewModels
{
    public class ApplicationState : BaseViewModel
    {
        private Domain.Filters.Filter _filter;
        private readonly IArticlesService _serviceArticles;
        public event EventHandler? StateChanged;
        public Domain.Filters.Filter CurrentFilter
        {
            get => _filter;
            set
            {
                _filter = value;
                NotifyPropertyChanged(nameof(CurrentFilter));
            }
        }
        public ApplicationState(IArticlesService serviceArticles)
        {
            _serviceArticles = serviceArticles;
            _filter = new Domain.Filters.Filter();
        }

        public async Task<ObservableCollection<ArticleDTO>> LoadArticles()
        {
            return await _serviceArticles.GetArticles(_filter);
        }

        //Metod för att uppdatera filter
        public async void UpdateFilter(Domain.Filters.Filter filter)
        {
            CurrentFilter = filter;
            OnStageChanged();
        }

       
        private void OnStageChanged() => StateChanged?.Invoke(this, EventArgs.Empty);

    }
}
