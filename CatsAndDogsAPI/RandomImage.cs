using Newtonsoft.Json;

namespace CatsAndDogsAPI
{
    /// <summary>
    /// A random image from the API
    /// </summary>
    public class RandomImage
    {
        public string id { get; set; } = null!;
        public string url { get; set; } = null!;
        public int width { get; set; }
        public int height { get; set; }
    }

    public static class CatAndDogAPIHelper
    {
        private static readonly HttpClient _httpClient = new();

        static CatAndDogAPIHelper()
        {
            _httpClient.BaseAddress = new Uri("https://api.thecatapi.com/v1/");
        }

        /// <summary>
        /// Get a specific number of random images
        /// from the cat/dog APIs
        /// </summary>
        /// <param name="numImages">Number of images to retrieve</param>
        /// <returns></returns>
        public static async Task<RandomImage[]> GetRandomImages(int numImages = 1)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("images/search");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                RandomImage[] randomImages = JsonConvert.DeserializeObject<RandomImage[]>(data);
                return randomImages;
            }
            else
            {
                return null;
            }
        }
    }
}