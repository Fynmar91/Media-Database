using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Downloaders
{
	public class Downloader
	{
		public void DownloadImageIMDB(string mediaName, string target)
		{
			string source = FindImageIMDB(mediaName.Replace(" ", "+"));

			using (WebClient client = new WebClient())
			{
				client.DownloadFile(new Uri(source), target);
				// OR 
				//client.DownloadFileAsync(new Uri(url), @"c:\temp\image35.png");
			}
		}

		private string FindImageIMDB(string url)
		{
			//string targetUrl = "https://www.imdb.com/find?q=ghost+in+the+shell+(1995)";
			string targetUrl = "https://www.imdb.com/find?q=" + url;
			Console.WriteLine(targetUrl);

			// For speed of dev, I use a WebClient
			WebClient client = new WebClient();
			string html = client.DownloadString(targetUrl);

			// Load the Html into the agility pack
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(html);

			// Now, using LINQ to get all Images
			List<HtmlNode> imageNodes = null;
			imageNodes = (from HtmlNode node in doc.DocumentNode.SelectNodes("//img")
						  where node.Name == "img" && node.ParentNode.Attributes["href"] != null
						  select node).ToList();


			foreach (HtmlNode node in imageNodes)
			{
				Console.WriteLine(node.Attributes["src"].Value);
			}


			string input = imageNodes[0].Attributes["src"].Value.ToString();

			int index = input.IndexOf("_V1_");
			if (index > 0)
			{
				input = input.Substring(0, index + 4);
			}

			return (input + ".jpg");
		}
	}
}
