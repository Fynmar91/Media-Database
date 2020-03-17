using HtmlAgilityPack;
using MediaClass;
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
		public string GetImage(string folder, Media media)
		{			
			string searchTerm = media.MyTitle.MyValue;

			string invalid = new string(System.IO.Path.GetInvalidFileNameChars()) + new string(System.IO.Path.GetInvalidPathChars());

			if (media.MyTitle.MyType.MyValue == "Film" && media.MyReleaseDate.MyValue != null && media.MyReleaseDate.MyValue != "")
			{
				searchTerm += "(" + media.MyReleaseDate.MyValue + ")";
			}
			else if (media.MyTitle.MyType.MyValue == "Serie" && media.MyTitle.MySeason.MyValue > 0)
			{
				searchTerm += media.MyTitle.MySeason;
			}
			foreach (char c in invalid)
			{
				searchTerm = searchTerm.Replace(c.ToString(), "");
			}

			if (media.MyTitle.MyType.MyValue == "Buch")
			{
				DownloadImageGoodReads(searchTerm, folder + searchTerm + ".jpg");
			}
			else if (media.MyTitle.MyType.MyValue == "Web-Novel")
			{
				DownloadImageNovelUpdates(searchTerm, folder + searchTerm + ".jpg");
			}
			else if (media.MyTitle.MyType.MyValue == "Film")
			{

				DownloadImageIMDB(searchTerm, folder + searchTerm + ".jpg", false);
			}
			else if (media.MyTitle.MyType.MyValue == "Serie")
			{
				DownloadImageIMDB(searchTerm, folder + searchTerm + ".jpg", true);
			}
			else if (media.MyTitle.MyType.MyValue == "Anime")
			{
				DownloadImageMyAnimeList(searchTerm, folder + searchTerm + ".jpg", true);
			}
			else if (media.MyTitle.MyType.MyValue == "Anime-Film")
			{
				DownloadImageMyAnimeList(searchTerm, folder + searchTerm + ".jpg", true);
			}

			if (searchTerm != null)
			{
				return searchTerm + ".jpg";

			}
			else
			{
				return null;
			}
		}


		private void DownloadImageGoodReads(string mediaName, string target)
		{
			string source = FindImageGoodReads(mediaName.Replace(" ", "+"));

			if (source != null)
			{
				using (WebClient client = new WebClient())
				{
					client.Headers.Add("User-Agent: Other");
					client.DownloadFile(new Uri(source), target);
				}
			}
		}

		private void DownloadImageNovelUpdates(string mediaName, string target)
		{
			string source = FindImageNovelUpdates(mediaName.Replace(" ", "+"));

			if (source != null)
			{
				using (WebClient client = new WebClient())
			{
				client.Headers.Add("User-Agent: Other");
				client.DownloadFile(new Uri(source), target);
				}
			}
		}

		private void DownloadImageIMDB(string mediaName, string target, bool show)
		{
			string source = FindImageIMDB(mediaName.Replace(" ", "+"), show);

			if (source != null)
			{
				using (WebClient client = new WebClient())
			{
				client.Headers.Add("User-Agent: Other");
				client.DownloadFile(new Uri(source), target);
				}
			}
		}

		private void DownloadImageMyAnimeList(string mediaName, string target, bool show)
		{
			string source = FindImageMyAnimeList(mediaName, show);

			if (source != null)
			{
				using (WebClient client = new WebClient())
				{
					client.Headers.Add("User-Agent: Other");
					client.DownloadFile(new Uri(source), target);
				}
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


			if (imageNodes.Count > 0 && imageNodes[0] != null)
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

			if (imageNodes.Count > 0 && imageNodes[0] != null)
			{
				string input;

				if (!imageNodes[0].Attributes["src"].Value.ToString().Contains(".png"))
				{
					input = imageNodes[0].Attributes["src"].Value.ToString();
				}
				else
				{
					input = imageNodes[4].Attributes["src"].Value.ToString();
				}

				int index = input.IndexOf("._");
				if (index > 0)
				{
					input = input.Substring(0, index);
				}

				return (input + ".jpg");
			}

			return null;
		}

		private string FindImageIMDB(string url, bool show)
		{
			string targetUrl;

			if (show)
			{
				targetUrl = "https://www.imdb.com/find?q=" + url + "&s=tt&ttype=tv";
			}
			else
			{
				targetUrl = "https://www.imdb.com/find?q=" + url + "&s=tt&ttype=ft";
			}

			WebClient client = new WebClient();
			client.Headers.Add("User-Agent: Other");
			string html = client.DownloadString(targetUrl);

			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(html);

			List<HtmlNode> imageNodes = null;
			imageNodes = (from HtmlNode node in doc.DocumentNode.SelectNodes("//img")
						  where node.Name == "img" && node.ParentNode.Attributes["href"] != null && node.Attributes["src"] != null
						  select node).ToList();

			if (imageNodes.Count > 0 && imageNodes[0] != null)
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

		private string FindImageMyAnimeList(string url, bool show)
		{
			string targetUrl = targetUrl = "https://myanimelist.net/anime.php?q=" + url;	

			WebClient client = new WebClient();
			client.Headers.Add("User-Agent: Other");
			string html = client.DownloadString(targetUrl);

			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(html);

			List<HtmlNode> imageNodes = null;
			imageNodes = (from HtmlNode node in doc.DocumentNode.SelectNodes("//img")
						  where node.Name == "img" && node.Attributes["data-src"] != null 
						  select node).ToList();

			if (imageNodes.Count > 0 && imageNodes[0] != null)
			{
				string input = imageNodes[0].Attributes["data-src"].Value.ToString();
				input = input.Replace("/r/50x70", "");

				int index = input.IndexOf(".jpg");
				if (index > 0)
				{
					input = input.Substring(0, index);
				}

				return (input + "l.jpg");
			}

			return null;
		}
	}
}
