using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Domain.Filters;
using Presentation.Command;

namespace Presentation.ViewModels.Filter
{
    public class ApplyFilterViewModel : BaseViewModel
    {
       
        private readonly ApplicationState _state;
        public List<SearchIn> searchinOptions { get; } = Enum.GetValues(typeof(SearchIn)).Cast<SearchIn>().ToList();
        public List<SortBy> sortbyOptions { get; } = Enum.GetValues(typeof(SortBy)).Cast<SortBy>().ToList();
        public List<Language> langOptions { get; } = Enum.GetValues(typeof(Language)).Cast<Language>().ToList();
        private DateTime? _from;
        private DateTime? _to;
        public DateTime? From
        {
            get => _from; set
            {
                _from = value;
                NotifyPropertyChanged(nameof(From));
            }
        }
        public DateTime? To
        {
            get => _to; set
            {
                _to = value;
                NotifyPropertyChanged(nameof(To));
            }
        }
        private string[] Domains;
        private string _domainEntry;
        public string DomainEntry
        {
            get => _domainEntry; set
            {
                _domainEntry = value;
                NotifyPropertyChanged(nameof(DomainEntry));
                DomainHandler(_domainEntry);
            }
        }
        private Language? _selectedLanguage;

        private SearchIn? _selectedSearchIn;

        private SortBy? _selectedSortBy;
        private string _q;
     
        public Language? SelectedLanguage
        {
            get => _selectedLanguage; set
            {
                _selectedLanguage = value;
                NotifyPropertyChanged(nameof(SelectedLanguage));
            }
        }
        public string Q
        {
            get => _q; set
            {
                _q = value;
                NotifyPropertyChanged(nameof(Q));
            }
        }
        public SortBy? SelectedSortBy
        {
            get => _selectedSortBy; set
            {
                _selectedSortBy = value;
                NotifyPropertyChanged(nameof(SelectedSortBy));
            }
        }
        public SearchIn? SelectedSearchIn
        {
            get => _selectedSearchIn; set
            {
                _selectedSearchIn = value;
                NotifyPropertyChanged(nameof(SelectedSearchIn));
            }
        }
   
        public ICommand UpdateFilter { get; }

        public ApplyFilterViewModel(ApplicationState state)
        {
            _state = state;
            UpdateFilter = new RelayCommandAsync(ApplyNewFilter);

            _from = null;
            _to = null;

        }

        private async Task ApplyNewFilter()
        {
            Domain.Filters.Filter filter = new Domain.Filters.Filter();
            filter.Page = 1;
            filter.q = Q;
            filter.SortBy = SelectedSortBy;
            filter.SearchIn = SelectedSearchIn;
            filter.Language = SelectedLanguage;
            filter.Domains = Domains;
            CheckDateTime(filter);
            _state.UpdateFilter(filter);
            await GoToMainDisplay();
        }

        private async Task GoToMainDisplay()
        {
            await Shell.Current.GoToAsync("//MainDisplay");
        }

        private void DomainHandler(string entry)
        {
            entry.ToLowerInvariant();
            entry = entry.Replace(" ", "");
            Domains = entry.Split(",").ToArray();
        }

        private void CheckDateTime(Domain.Filters.Filter filter)
        {
            if (From == null || To == null)
                return;

     
            filter.DateFilter = new DateFilter((DateTime)From, (DateTime)To);
        }

    }
}
