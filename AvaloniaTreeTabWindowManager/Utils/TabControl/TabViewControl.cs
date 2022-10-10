using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaTreeTabWindowManager.Utils.TreeCollections;
using AvaloniaTreeTabWindowManager.ViewModels;
using ReactiveUI;

namespace AvaloniaTreeTabWindowManager.Utils.TabControl
{
    public static class TabViewControl
    {
        public static TreeViewModelCollection<TabWindowViewModel, ViewNode> Tree { get; set; }

        public static void Init(TabWindowViewModel vm, ViewNode root)
        {
            Tree = new TreeViewModelCollection<TabWindowViewModel, ViewNode>(vm, root);
        }

        private static ViewNode? GetNodeByViewModel(TabViewModelBase? vm)
        {
            return vm == null ? null : Tree.ItemsCollection.FirstOrDefault(x => x.ViewModel == vm);
        }

        //public void Detach(MainWindow wnd, MainWindowViewModel vm, ViewNode node)
        //{
        //    Tree.SelectedList.Add((wnd, vm), node);

        //}

        //public void Attach(ViewNode node)
        //{

        //}

        //public bool AddAndSwitchView(PageViewModelBase? parent, PageViewModelBase? child)
        //{
        //    if (AddView(parent, child))
        //        SwitchView(GetNodeByViewModel(child));

        //    return false;
        //}

        public static bool AddAndSwitchView<T>(TabViewModelBase? parent, Func<T> child) where T : TabViewModelBase
        {
            var type = typeof(T);
            var inst = Tree.ItemsCollection.FirstOrDefault(x => x.ViewModel.GetType().Name == type.Name);
            return inst == null ? SwitchView(AddView(parent, child)) : SwitchView(inst);
        }

        public static T AddView<T>(TabViewModelBase? parent, Func<T> child) where T : TabViewModelBase
        {
            var parentNode = GetNodeByViewModel(parent);
            var ch         = child.Invoke();
            Tree.AddChild(parentNode, new ViewNode(ch));
            return ch;
        }

        public static void RemoveView()
        {

        }

        public static bool SwitchView(ViewNode? node)
        {
            if (node == null) return false;
            var mvm = Tree.GetVmByItem(node);
            mvm.Content = node.ViewModel;
            var vms = Tree.GetAllChildNodesByVmRoot(mvm);
            foreach (var x in vms)
                x.IsSelected = false;
            node.IsSelected = true;
            if (!mvm.Wnd.IsActive)
                mvm.Wnd.Activate();
            return true;
        }

        public static bool SwitchView(TabViewModelBase vm) => SwitchView(GetNodeByViewModel(vm));
    }
}
