using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaTreeTabWindowManager.Utils.Collections;

namespace AvaloniaTreeTabWindowManager.Utils.TreeCollections
{
    public interface ITreeNode<T> where T : ISelected
    {
        T?                                      Parent { get; set; }
        ObservableCollectionWithSelectedItem<T> Childs { get; set; }

        public void AddChild(T    child);
        public void RemoveChild(T child);
    }
}
