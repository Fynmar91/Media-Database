using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperClasses
{
	public class Settings
	{
		public string MyFolder { get; set; }
		public string MyImageFolder
		{
			get
			{
				if (MyFolder != null)
				{
					return System.IO.Path.Combine(MyFolder, @"Bilder\");
				}
				else
				{
					return null;
				}
			}
		}

		public Settings()
		{
		}

		public void GetFolder()
		{
			var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
			if (dialog.ShowDialog().GetValueOrDefault())
			{
				MyFolder = dialog.SelectedPath.ToString();
			}
		}

	}
}
