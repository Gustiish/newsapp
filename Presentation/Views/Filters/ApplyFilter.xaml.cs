using Presentation.ViewModels.Filter;

namespace Presentation.Views.Filters;

public partial class ApplyFilter : ContentPage
{
    public ApplyFilter(ApplyFilterViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

    }
}