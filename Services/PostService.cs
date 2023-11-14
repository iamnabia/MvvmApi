using MVVM_API_SampleProject.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;

namespace MVVM_API_SampleProject.Services
{
    public class PostService
    {
        private readonly HttpClient _client; 
        private readonly JsonSerializerOptions _serializerOptions;
        private readonly string _baseUrl = "https://jsonplaceholder.typicode.com";

        public PostService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<ObservableCollection<Post>> GetPostsAsync() 
        {
            var url = $"{_baseUrl}/posts";
            try
            {
                var response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<ObservableCollection<Post>>(content, _serializerOptions);
                }
                return null;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}
