using System.Text.Json.Serialization;

namespace Recipendium.UI.Models
{
    public class WPRMResult
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("html")]
        public string Html { get; set; }
    }
}
