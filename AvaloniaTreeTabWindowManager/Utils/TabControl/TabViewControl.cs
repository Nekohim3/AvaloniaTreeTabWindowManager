using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Collections;
using AvaloniaTreeTabWindowManager.Utils.TreeCollections;
using AvaloniaTreeTabWindowManager.ViewModels;
using AvaloniaUtils.Utils.Collections;
using DynamicData.Kernel;
using ReactiveUI;

namespace AvaloniaTreeTabWindowManager.Utils.TabControl
{
    public class TabViewControl
    {
        public TabViewControl()
        {
            var q = new TreeViewModelCollection<TabWindowViewModel, TreeViewModelCollection<TabWindowViewModel, ViewNode>(null, null);
        }
    }
    //public static class TabViewControl
    //{
    //    private     static ulong                                                                          _viewCounter;
    //    public static      ObservableCollectionWithSelectedItem<TreeViewModelCollection<TabWindowViewModel, ViewNode>> ListOfTree { get; set; } = new();

    //    public static void Init(int imo, TabWindowViewModel vm, ViewNode root)
    //    {
    //        //_viewCounter     = 0;
    //        ListOfTree.Add(new TreeViewModelCollection<TabWindowViewModel, ViewNode>(vm, root, imo));
    //        //Tree             = new TreeViewModelCollection<TabWindowViewModel, ViewNode>(vm, root);
    //        //root.ViewCounter = ++_viewCounter;
    //    }

    //    public static void Dispose(int imo)
    //    {
    //        //диспозим судно
    //        var item = ListOfTree.FirstOrDefault(x => x.Imo == imo);
    //        if(item != null) ListOfTree.Remove(item);
    //    }

    //    private static ViewNode? GetNodeByViewModel(TabViewModelBase? vm, int? imo = null)
    //    {
    //        var tree = imo.HasValue ? ListOfTree.FirstOrDefault(x => x.Imo == imo.Value) : ListOfTree.SelectedItem;
    //        if (tree == null) throw new NullReferenceException();
    //        return vm == null ? null : tree.ItemsCollection.FirstOrDefault(x => x.ViewModel == vm);
    //    }

    //    //public void Detach(MainWindow wnd, MainWindowViewModel vm, ViewNode node)
    //    //{
    //    //    Tree.SelectedList.Add((wnd, vm), node);

    //    //}

    //    //public void Attach(ViewNode node)
    //    //{

    //    //}

    //    //public bool AddAndSwitchView(PageViewModelBase? parent, PageViewModelBase? child)
    //    //{
    //    //    if (AddView(parent, child))
    //    //        SwitchView(GetNodeByViewModel(child));

    //    //    return false;
    //    //}

    //    public static bool AddAndSwitchView<T>(TabViewModelBase? parent, Func<T> child, int? imo = null) where T : TabViewModelBase
    //    {
    //        var type = typeof(T);
    //        var tree = imo.HasValue ? ListOfTree.FirstOrDefault(x => x.Imo == imo.Value) : ListOfTree.SelectedItem;
    //        if (tree == null) throw new NullReferenceException();
    //        var inst = tree.ItemsCollection.FirstOrDefault(x => x.ViewModel.GetType().Name == type.Name);
    //        return inst == null ? SwitchView(imo, AddView(parent, child, imo)) : SwitchView(imo, inst);
    //    }

    //    public static T AddView<T>(TabViewModelBase? parent, Func<T> child, int? imo = null) where T : TabViewModelBase
    //    {
    //        var tree = imo.HasValue ? ListOfTree.FirstOrDefault(x => x.Imo == imo.Value) : ListOfTree.SelectedItem;
    //        if (tree == null) throw new NullReferenceException();
    //        var parentNode = GetNodeByViewModel(parent, imo);
    //        var ch         = child.Invoke();
    //        tree.AddChild(parentNode, new ViewNode(ch));
    //        return ch;
    //    }

    //    public static void RemoveView()
    //    {

    //    }

    //    public static bool SwitchView(ViewNode? node, int? imo = null)
    //    {
    //        if (node == null) return false;
    //        //node.ViewCounter = ++_viewCounter;
    //        var mvm = ListOfTree[imo].GetVmByItem(node);
    //        mvm.Content = node.ViewModel;
    //        //var vms = Tree.GetAllChildNodesByVmRoot(mvm);
    //        //foreach (var x in vms)
    //        //    x.IsSelected = false;
    //        //node.IsSelected = true;
    //        if (!mvm.Wnd.IsActive)
    //            mvm.Wnd.Activate();
    //        return true;
    //    }

    //    public static bool SwitchView(int imo, TabViewModelBase vm) => SwitchView(imo, GetNodeByViewModel(imo, vm));

    //    public static TreeViewModelCollection<TabWindowViewModel, ViewNode> GetTreeByImo(int? imo = null)
    //    {
    //        var tree = imo.HasValue ? ListOfTree.FirstOrDefault(x => x.Imo == imo.Value) : ListOfTree.SelectedItem;
    //        if (tree == null) throw new NullReferenceException();
    //        return tree;
    //    }
    //}
}
