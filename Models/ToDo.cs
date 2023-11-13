using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MVVM_API_SampleProject.Models
{
    public class ToDo : ObservableObject
    {
        private bool _completed;
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed
        {
            get => _completed; set => SetProperty(ref _completed, value);
        }
    }


}