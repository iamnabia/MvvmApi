using CommunityToolkit.Mvvm.ComponentModel;
using MVVM_API_SampleProject.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using System.Windows.Input;


namespace MVVM_API_SampleProject.ViewModels;

internal partial class ToDoViewModel : ObservableObject, IDisposable
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

    public ObservableCollection<Post> Posts;

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}