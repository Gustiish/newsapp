using Presentation.ViewModels.Details;

namespace Presentation.Views.Details;

public partial class ArticleDetails : ContentPage
{
	public ArticleDetails(DetailsViewViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}


}