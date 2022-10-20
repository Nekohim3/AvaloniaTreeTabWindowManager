using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using AvaloniaTreeTabWindowManager.Utils.TabControl;
using AvaloniaTreeTabWindowManager.Utils.TreeCollections;
using AvaloniaTreeTabWindowManager.Views;
using AvaloniaUtils.Utils.ViewModels;

namespace AvaloniaTreeTabWindowManager.ViewModels
{
    public abstract class TabViewModelBase : ViewModelBase
    {
        public string             Title { get; set; }
        public TabWindowViewModel WndVm { get; set; }
        //public abstract bool   IsEditable             { get; }
        //public abstract bool   AllowMultipleInstances { get; }

        protected TabViewModelBase(TabWindowViewModel wnd)
        {
            WndVm = wnd;
            Title = GetType().Name;
        }
    }

    public static class TabViewModelBaseExtension
    {
        //public static bool AddAndSwitchView<T>(this TabViewModelBase parent, Func<T> child) where T : TabViewModelBase => TabViewControl.AddAndSwitchView(parent, child);
        //public static T    AddView<T>(this          TabViewModelBase parent, Func<T> child) where T : TabViewModelBase => TabViewControl.AddView(parent, child);
        //public static bool SwitchView(this          TabViewModelBase view) => TabViewControl.SwitchView(view);
        //public static bool SwitchView(this          ViewNode         node) => TabViewControl.SwitchView(node);
    }
}
