using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Presentation.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private string _statusMessage;
        private Visibility _isVisible;
        public Visibility IsVisible
        {
            get => _isVisible; 
            set
            {
                _isVisible = value;
                NotifyPropertyChanged(nameof(IsVisible));
            }
        }
        public string StatusMessage 
        {
            get => _statusMessage; 
            set
            {
                _statusMessage = value;
                NotifyPropertyChanged(nameof(StatusMessage));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public BaseViewModel()
        {
            _statusMessage = "";
            _isVisible = Visibility.Hidden;
        }

        public async Task DisplayStatusMessage(string message)
        {
            StatusMessage = message;
            IsVisible = Visibility.Visible;
            Task.Delay(3000);
            IsVisible = Visibility.Hidden;
            StatusMessage = "";
        }



    }
}
