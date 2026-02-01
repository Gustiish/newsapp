using Microsoft.Extensions.DependencyInjection;
using Presentation.ViewModels.Filter;

namespace Presentation;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new AppShell());
	}

 
}