using CommunityToolkit.Mvvm.ComponentModel;
using MVVM_API_SampleProject.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using System.Windows.Input;

namespace MVVM_API_SampleProject.ViewModels;
internal partial class PostViewModel : ObservableObject, IDisposable
{
    private readonly HttpClient _client;

    private readonly JsonSerializerOptions _serializerOptions;
    private readonly string _baseUrl = "https://jsonplaceholder.typicode.com";

    [ObservableProperty]
    public int _UserOd;
    [ObservableProperty]
    public int _Id;
    [ObservableProperty]
    public string _Title;
    [ObservableProperty]
    public string _Body;
    [ObservableProperty]
    public ObservableCollection<Post> _posts;

    public PostViewModel()
    {
        _client = new HttpClient();
        Posts = new ObservableCollection<Post>();
        _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public ICommand GetPostsCommand => new Command(async () => await LoadPostsAsync());

    private async Task LoadPostsAsync()
    {
        var url = $"{_baseUrl}/posts";
        try
        {
            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Posts = JsonSerializer.Deserialize<ObservableCollection<Post>>(content, _serializerOptions);


            }
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
        }
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}