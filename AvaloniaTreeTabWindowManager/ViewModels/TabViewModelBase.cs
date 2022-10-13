using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaTreeTabWindowManager.Utils.TabControl;
using AvaloniaTreeTabWindowManager.Utils.TreeCollections;
using AvaloniaUtils.Utils.ViewModels;

namespace AvaloniaTreeTabWindowManager.ViewModels
{
    public enum Modules
    {
        PMS,
        ISM,
        CREW,
        MRV,
        BDG,
    }
    public abstract class TabViewModelBase : ViewModelBase
    {
        public virtual string  Title  { get; set; }
        //public abstract Modules Module { get; set; }
        protected TabViewModelBase()
        {
            Title = GetType().Name;
        }
    }

    public static class TabViewModelBaseExtension
    {
        public static bool AddAndSwitchView<T>(this TabViewModelBase parent, Func<T> child) where T : TabViewModelBase => TabViewControl.AddAndSwitchView(parent, child);
        public static T    AddView<T>(this          TabViewModelBase parent, Func<T> child) where T : TabViewModelBase => TabViewControl.AddView(parent, child);
        public static bool SwitchView(this          TabViewModelBase view) => TabViewControl.SwitchView(view);
        public static bool SwitchView(this          ViewNode         node) => TabViewControl.SwitchView(node);
    }
}
