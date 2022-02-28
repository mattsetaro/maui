using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Graphics;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.Storage.Search;
using Windows.UI.ViewManagement;

namespace Microsoft.Maui.Controls.Compatibility.Platform.UWP
{
	internal class WindowsPlatformServices : IPlatformServices
	{
		readonly UISettings _uiSettings = new UISettings();

		public WindowsPlatformServices()
		{
			_uiSettings.ColorValuesChanged += UISettingsColorValuesChanged;
		}

		void UISettingsColorValuesChanged(UISettings sender, object args)
		{
			Application.Current.Dispatcher.DispatchIfRequired(() =>
				Application.Current?.TriggerThemeChanged(new AppThemeChangedEventArgs(Application.Current.RequestedTheme)));
		}

		public OSAppTheme RequestedTheme =>
			Microsoft.UI.Xaml.Application.Current.RequestedTheme == ApplicationTheme.Dark
			? OSAppTheme.Dark
			: OSAppTheme.Light;
	}
}