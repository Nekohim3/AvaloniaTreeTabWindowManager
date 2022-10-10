using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaTreeTabWindowManager.ViewModels
{
    public class TabViewModelBase : ViewModelBase
    {
        public virtual string Title { get; set; }
        protected TabViewModelBase()
        {
            Title = GetType().Name;
        }
    }

    public static class TabViewModelBaseExtension
    {
        public static bool AddAndSwitchView<T>(this TabViewModelBase parent, Func<T> child) where T : TabViewModelBase => g.TabViewControl.AddAndSwitchView(parent, child);
        public static bool AddView<T>(this          TabViewModelBase parent, Func<T> child) where T : TabViewModelBase => g.TabViewControl.AddView(parent, child);
        public static bool SwitchView(this          TabViewModelBase view) => g.TabViewControl.SwitchView(view);
        public static bool SwitchView(this          ViewNode         node) => g.TabViewControl.SwitchView(node);
    }
}
