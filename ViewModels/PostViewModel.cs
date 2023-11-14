using CommunityToolkit.Mvvm.ComponentModel;
using MVVM_API_SampleProject.Models;
using MVVM_API_SampleProject.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using System.Windows.Input;

namespace MVVM_API_SampleProject.ViewModels;
internal partial class PostViewModel : ObservableObject, IDisposable
{
    private readonly PostService _postService;

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
        Posts = new ObservableCollection<Post>();
        _postService = new PostService();
    }

    public ICommand GetPostsCommand => new Command(async () => await LoadPostsAsync());

    private async Task LoadPostsAsync()
    {
        Posts = await _postService.GetPostsAsync();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}