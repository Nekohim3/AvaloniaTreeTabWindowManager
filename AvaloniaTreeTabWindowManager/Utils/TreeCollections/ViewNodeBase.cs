using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using AvaloniaTreeTabWindowManager.ViewModels;
using AvaloniaUtils.Utils.Collections;
using AvaloniaUtils.Utils.Trees;
using AvaloniaUtils.Utils.ViewModels;
using ReactiveUI;

namespace AvaloniaTreeTabWindowManager.Utils.TreeCollections
{
    public class ViewNodeBase : ViewModelBase, ITreeNode<ViewNodeBase>, ISelected
    {
        private TabViewModelBase _viewModel;

        public TabViewModelBase ViewModel
        {
            get => _viewModel;
            set => this.RaiseAndSetIfChanged(ref _viewModel, value);
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get => _isSelected;
            set => this.RaiseAndSetIfChanged(ref _isSelected, value);
        }
        
        private ViewNodeBase? _parent;

        public ViewNodeBase? Parent
        {
            get => _parent;
            set => this.RaiseAndSetIfChanged(ref _parent, value);
        }

        private ObservableCollectionWithSelectedItem<ViewNodeBase> _childs = new();

        public ObservableCollectionWithSelectedItem<ViewNodeBase> Childs
        {
            get => _childs;
            set => this.RaiseAndSetIfChanged(ref _childs, value);
        }

        public bool IsRoot => Parent == null;
        public int  Depth  => Parent == null ? 0 : Parent.Depth + 1;

        public ReactiveCommand<Unit, Unit> SwitchCmd { get; }
        public ReactiveCommand<Unit, Unit> CloseCmd  { get; } 
        public ReactiveCommand<Unit, Unit> EscapeCmd { get; }

        public ViewNodeBase(TabViewModelBase vm, ViewNodeBase? parent = null)
        {
            _viewModel = vm;
            _parent    = parent;
            SwitchCmd  = ReactiveCommand.Create(OnSwitch);
            CloseCmd   = ReactiveCommand.Create(OnClose);
            EscapeCmd  = ReactiveCommand.Create(OnEscape);
        }

        public virtual void OnSwitch()
        {
            throw new NotImplementedException();
        }

        public virtual void OnClose()
        {
            throw new NotImplementedException();
        }

        public virtual void OnEscape()
        {
            throw new NotImplementedException();
        }
        
        public virtual void AddChild(ViewNodeBase child)
        {
            Childs.Add(child);
            child.Parent = this;
        }

        public virtual void RemoveChild(ViewNodeBase child)
        {
            child.Parent = null;
            Childs.Remove(child);
        }

        public ViewNodeBase GetFirst(ViewNodeBase item)
        {
            throw new NotImplementedException();
        }

        public ViewNodeBase GetNext(ViewNodeBase  item)
        {
            throw new NotImplementedException();
        }

        public ViewNodeBase GetPrev(ViewNodeBase  item)
        {
            throw new NotImplementedException();
        }

        public ViewNodeBase GetLast(ViewNodeBase  item)
        {
            throw new NotImplementedException();
        }
    }
}
