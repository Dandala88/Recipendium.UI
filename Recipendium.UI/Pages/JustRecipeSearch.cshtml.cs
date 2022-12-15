using Core.HttpDynamo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipendium.UI.Models;

namespace Recipendium.UI.Pages
{
    public class JustRecipeSearchModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public string Message { get; set; }
        public List<WPRMResult> ResultPages { get; set; }

        public JustRecipeSearchModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnPost(string query, int limit)
        {
            Message = string.Empty;
            if (!string.IsNullOrEmpty(query))
            {
                var lowQuery = query.ToLower();

                if (!query.Contains("recipe"))
                {
                    if (!query.Contains("-recipe"))
                    {
                        query += " recipe";
                        Message = "We noticed your search did not include recipe so we've included it for you. If you'd like to force search without the word recipe, please add '-recipe' to your search.";
                    }
                }

                var results = await HttpDynamo.GetRequestAsync<List<WPRMResult>>(_httpClientFactory, "https://recipendiumapi20221210174136.azurewebsites.net/Recipe?q=" + query + "&limit=" + limit);

                ResultPages = results;
            }
        }
    }
}
