using CommunityToolkit.Mvvm.ComponentModel;
using MVVM_API_SampleProject.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using System.Windows.Input;
using MVVM_API_SampleProject.Services;


namespace MVVM_API_SampleProject.ViewModels;

internal partial class ToDoViewModel : ObservableObject, IDisposable
{
    private readonly ToDoService _todoService;

    [ObservableProperty]
    public int _UserId;
    [ObservableProperty]
    public int _Id;
    [ObservableProperty]
    public string _Title;
    [ObservableProperty]
    public bool _Completed;
    [ObservableProperty]
    public ObservableCollection<ToDo> _todos;

    public ICommand GetToDoCommand { get; }

    public ToDoViewModel()
    {
        Todos = new ObservableCollection<ToDo>();
        _todoService = new ToDoService();

        GetToDoCommand = new Command(async () => await LoadToDoAsync());
        Task.Run(async () => await LoadToDoAsync());
    }


    private async Task LoadToDoAsync()
    {
        Todos = await _todoService.GetToDoAsync();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}