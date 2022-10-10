using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaTreeTabWindowManager.Utils.Collections;
using AvaloniaTreeTabWindowManager.ViewModels;
using System.Collections.ObjectModel;

namespace AvaloniaTreeTabWindowManager.Utils.TreeCollections
{
    public class TreeViewModelCollection<TVm, T> : ReactiveObject where T : ITreeNode<T>, ISelected where TVm : TabWindowViewModel
    {
        private T _root;

        public T Root
        {
            get => _root;
            set => this.RaiseAndSetIfChanged(ref _root, value);
        }

        private ObservableCollection<T> _itemsCollection = new();

        public ObservableCollection<T> ItemsCollection
        {
            get => _itemsCollection;
            set => this.RaiseAndSetIfChanged(ref _itemsCollection, value);
        }


        private Dictionary<TVm, T> _headList = new();

        public Dictionary<TVm, T> HeadList
        {
            get => _headList;
            set => this.RaiseAndSetIfChanged(ref _headList, value);
        }

        public TreeViewModelCollection(TVm vm, T root)
        {
            _root = root;
            ItemsCollection.Add(_root);
            HeadList.Add(vm, _root);
        }

        public TVm GetVmByItem(T item)
        {
            while (item.Parent != null && !HeadList.ContainsValue(item))
                item = item.Parent;
            return HeadList.First(x => x.Value.Equals(item)).Key;
        }

        public List<T> GetAllChildNodesByVmRoot(TVm vm)
        {
            var item = HeadList[vm];
            return GetAllChildNodesByVmRoot(vm, item);
        }

        private List<T> GetAllChildNodesByVmRoot(TVm vm, T item, List<T>? items = null)
        {
            items ??= new List<T>();

            items.Add(item);
            foreach (var x in item.Childs)
                if (!HeadList.Where(c => !c.Key.Equals(vm)).Any(c => c.Value.Equals(x)))
                    GetAllChildNodesByVmRoot(vm, x, items);

            return items;
        }

        public List<T> GetAllChildNodes(T item, List<T>? items = null)
        {
            items ??= new List<T>();

            items.Add(item);
            foreach (var x in item.Childs)
                GetAllChildNodes(x, items);
            return items;
        }

        public bool AddChild(T? parent, T? child)
        {
            if (parent == null || child == null) return false;
            parent.AddChild(child);
            ItemsCollection.Add(child);
            return true;
        }

        public void RemoveChild(T parent, T child)
        {
            ItemsCollection.Remove(child);
            parent.RemoveChild(child);
        }

        public bool AddHead(TVm key, T value)
        {
            return HeadList.TryAdd(key, value);
        }

        public void RemoveHead(TVm key)
        {
            HeadList.Remove(key);
        }
    }
}
