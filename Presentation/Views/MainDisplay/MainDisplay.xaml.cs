using Presentation.ViewModels.MainDisplay;
using System.Threading.Tasks;

namespace Presentation.Views.MainDisplay;

public partial class MainDisplay : ContentPage
{
	public MainDisplay(MainDisplayViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

		if (BindingContext is MainDisplayViewModel vm)
		{
			await vm.ApplyFilters();
		}
    }
}