using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaTreeTabWindowManager.Views;
using ReactiveUI;

namespace AvaloniaTreeTabWindowManager.ViewModels
{
    public class TabWindowViewModel : TabViewModelBase
    {
        private TabViewModelBase _content;

        public TabViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public TabWindow Wnd { get; set; }

        public TabWindowViewModel(TabWindow wnd, TabViewModelBase vm)
        {
            Wnd      = wnd;
            _content = vm;
        }
    }
}
