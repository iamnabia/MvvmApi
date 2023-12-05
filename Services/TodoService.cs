using CommunityToolkit.Mvvm.ComponentModel;
using MVVM_API_SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVVM_API_SampleProject.Services
{
    internal class ToDoService
    {

        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _serializerOptions;
        private readonly string _baseUrl = "https://jsonplaceholder.typicode.com";

        public ToDoService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<ObservableCollection<ToDo>> GetToDoAsync()
        {
            var url = $"{_baseUrl}/todos";
            try
            {
                var response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<ObservableCollection<ToDo>>(content, _serializerOptions);
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
