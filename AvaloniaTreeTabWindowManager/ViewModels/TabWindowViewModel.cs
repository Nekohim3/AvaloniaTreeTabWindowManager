using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaTreeTabWindowManager.Utils.TreeCollections;
using AvaloniaTreeTabWindowManager.Views;
using AvaloniaUtils.Utils.Collections;
using AvaloniaUtils.Utils.ViewModels;
using DynamicData.Binding;
using ReactiveUI;

namespace AvaloniaTreeTabWindowManager.ViewModels
{
    public class TabWindowViewModel : ViewModelBase
    {
        private TabViewModelBase _content;

        public TabViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }
        

        //private ObservableCollectionWithSelectedItem<ViewNode> _tabList = new();

        //public ObservableCollectionWithSelectedItem<ViewNode> TabList
        //{
        //    get => _tabList;
        //    set => this.RaiseAndSetIfChanged(ref _tabList, value);
        //}

        public TabWindow Wnd { get; set; }

        public TabWindowViewModel(TabWindow wnd, TabViewModelBase vm)
        {
            //this.WhenAnyValue(x => x.Content).Subscribe(x => {RefreshTabList(); });
            Wnd      = wnd;
            _content = vm;
        }

        //public void RefreshTabList()
        //{

        //}
    }
}
