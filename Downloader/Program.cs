using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Downloaders
{
	class Program
	{
		static void Main(string[] args)
		{
			Downloader d = new Downloader();

			string searchTerm = "Ghost in the Shell" + " " + "(1995)";

			d.DownloadImageIMDB(searchTerm, "C:\\Users\\User-Y\\Google Drive\\Ablage\\Listen\\Mediendatenbank\\Bilder\\" + searchTerm + ".jpg");
		}
	}
}
