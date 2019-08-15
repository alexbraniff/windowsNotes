using Notes.UI.Domain.Infrastructure;
using Notes.UI.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Notes.UI.Domain.Models
{
    public class MainMenuItemModel<T> : INotifyPropertyChanged, IMenuItemModel where T : UserControl, new()
    {
        private string _name;
        public object DataContext;
        private T _content;
        private ScrollBarVisibility _horizontalScrollBarVisibilityRequirement;
        private ScrollBarVisibility _verticalScrollBarVisibilityRequirement;
        private Thickness _marginRequirement = new Thickness(16);

        public MainMenuItemModel(string name, object dataContext, IEnumerable<LinkModel> mainMenuLinks)
        {
            _name = name;
            DataContext = dataContext;
            MainMenuLinks = mainMenuLinks;
        }

        public string Name
        {
            get { return _name; }
            set { this.MutateVerbose(ref _name, value, RaisePropertyChanged()); }
        }

        public T Content
        {
            get
            {
                _content = _content ?? Activator.CreateInstance<T>();
                _content.DataContext = DataContext;
                return _content;
            }
        }

        public ScrollBarVisibility HorizontalScrollBarVisibilityRequirement
        {
            get { return _horizontalScrollBarVisibilityRequirement; }
            set { this.MutateVerbose(ref _horizontalScrollBarVisibilityRequirement, value, RaisePropertyChanged()); }
        }

        public ScrollBarVisibility VerticalScrollBarVisibilityRequirement
        {
            get { return _verticalScrollBarVisibilityRequirement; }
            set { this.MutateVerbose(ref _verticalScrollBarVisibilityRequirement, value, RaisePropertyChanged()); }
        }

        public Thickness MarginRequirement
        {
            get { return _marginRequirement; }
            set { this.MutateVerbose(ref _marginRequirement, value, RaisePropertyChanged()); }
        }

        public IEnumerable<LinkModel> MainMenuLinks { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }
    }
}
