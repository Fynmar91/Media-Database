using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HelperClasses
{
	public class Downloader
	{
		public void DownloadImageGoodReads(string mediaName, string target)
		{
			string source = FindImageGoodReads(mediaName.Replace(" ", "+"));

			using (WebClient client = new WebClient())
			{
				client.Headers.Add("User-Agent: Other");
				client.DownloadFile(new Uri(source), target);
			}
		}

		public void DownloadImageNovelUpdates(string mediaName, string target)
		{
			string source = FindImageNovelUpdates(mediaName.Replace(" ", "+"));

			using (WebClient client = new WebClient())
			{
				client.Headers.Add("User-Agent: Other");
				client.DownloadFile(new Uri(source), target);
			}
		}

		public void DownloadImageIMDB(string mediaName, string target)
		{
			string source = FindImageIMDB(mediaName.Replace(" ", "+"));

			using (WebClient client = new WebClient())
			{
				client.Headers.Add("User-Agent: Other");
				client.DownloadFile(new Uri(source), target);
			}
		}





		private string FindImageNovelUpdates(string url)
		{
			string targetUrl = "https://www.novelupdates.com/?s=" + url + "&post_type=seriesplans";

			WebClient client = new WebClient();
			client.Headers.Add("User-Agent: Other");
			string html = client.DownloadString(targetUrl);

			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(html);

			List<HtmlNode> imageNodes = null;
			imageNodes = (from HtmlNode node in doc.DocumentNode.SelectNodes("//a")
						  where node.Name == "a" && node.ParentNode.Attributes["class"] != null && node.Attributes["href"] != null
						  select node).ToList();

			client = new WebClient();
			client.Headers.Add("User-Agent: Other");
			html = client.DownloadString(imageNodes[12].Attributes["href"].Value.ToString());

			doc = new HtmlDocument();
			doc.LoadHtml(html);

			imageNodes = null;
			imageNodes = (from HtmlNode node in doc.DocumentNode.SelectNodes("//img")
						  where node.Name == "img" && node.ParentNode.Attributes["class"] != null && node.Attributes["src"] != null
						  select node).ToList();


			if (imageNodes[0] != null)
			{
				string input = imageNodes[0].Attributes["src"].Value.ToString();				

				return input;
			}

			return null;
		}


		private string FindImageGoodReads(string url)
		{
			string targetUrl = "https://www.goodreads.com/search?utf8=✓&q=" + url;

			WebClient client = new WebClient();
			client.Headers.Add("User-Agent: Other");
			string html = client.DownloadString(targetUrl);

			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(html);

			List<HtmlNode> imageNodes = null;
			imageNodes = (from HtmlNode node in doc.DocumentNode.SelectNodes("//img")
						  where node.Name == "img" && node.Attributes["class"] != null && node.Attributes["src"] != null
						  select node).ToList();

			if (imageNodes[0] != null)
			{
				string input = imageNodes[0].Attributes["src"].Value.ToString();

				int index = input.IndexOf("._");
				if (index > 0)
				{
					input = input.Substring(0, index + 2);
				}

				return (input + ".jpg");
			}

			return null;
		}

		private string FindImageIMDB(string url)
		{
			string targetUrl = "https://www.imdb.com/find?q=" + url;

			WebClient client = new WebClient();
			client.Headers.Add("User-Agent: Other");
			string html = client.DownloadString(targetUrl);

			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(html);

			List<HtmlNode> imageNodes = null;
			imageNodes = (from HtmlNode node in doc.DocumentNode.SelectNodes("//img")
						  where node.Name == "img" && node.ParentNode.Attributes["href"] != null && node.Attributes["src"] != null
						  select node).ToList();

			if (imageNodes[0] != null)
			{
				string input = imageNodes[0].Attributes["src"].Value.ToString();

				int index = input.IndexOf("_V1_");
				if (index > 0)
				{
					input = input.Substring(0, index + 4);
				}

				return (input + ".jpg");
			}

			return null;
		}
	}
}
