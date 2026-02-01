using Domain.DTOs;
using Presentation.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Presentation.ViewModels.Details
{
    [QueryProperty(nameof(Article), "article")]
    public class DetailsViewViewModel : BaseViewModel
    {

        private ArticleDTO _article;
        public ArticleDTO Article
        {
            get => _article; set
            {
                _article = value;
                NotifyPropertyChanged(nameof(Article));
            }
        }

        public ICommand MainDisplay { get; }
        public DetailsViewViewModel()
        {
            MainDisplay = new RelayCommandAsync(GoToMainDisplay);
        }

        private async Task GoToMainDisplay()
        {
            await Shell.Current.GoToAsync("//MainDisplay");
        }
        

    }
}
