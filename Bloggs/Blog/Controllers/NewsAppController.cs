using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NewsApp.Controllers
{
    public class NewsController : Controller
    {
        private const string ApiUrl = "https://newsapi.org/v2/top-headlines?sources=bbc-news&apiKey=553ca5ab0506413cba32c79a3ad6e10f";

        public async Task<IActionResult> Index()
        {
            List<NewsArticle> newsArticles = await GetNewsAsync();

            return View(newsArticles);
        }

        private async Task<List<NewsArticle>> GetNewsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(ApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    NewsApiResponse newsApiResponse = JsonConvert.DeserializeObject<NewsApiResponse>(responseBody);

                    return newsApiResponse?.Articles;
                }

                return null;
            }
        }
    }

    public class NewsArticle
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class NewsApiResponse
    {
        public List<NewsArticle> Articles { get; set; }
    }
}
