using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using AvaloniaTreeTabWindowManager.ViewModels;
using AvaloniaUtils.Utils.Collections;
using AvaloniaUtils.Utils.Trees;
using ReactiveUI;

namespace AvaloniaTreeTabWindowManager.Utils.TreeCollections
{
    public class ViewNode : TabViewModelBase, ITreeNode<ViewNode>, ISelected
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


        private ViewNode? _parent;

        public ViewNode? Parent
        {
            get => _parent;
            set => this.RaiseAndSetIfChanged(ref _parent, value);
        }

        private ObservableCollectionWithSelectedItem<ViewNode> _childs = new();

        public ObservableCollectionWithSelectedItem<ViewNode> Childs
        {
            get => _childs;
            set => this.RaiseAndSetIfChanged(ref _childs, value);
        }

        public ReactiveCommand<Unit, Unit> SwitchCmd { get; }
        public ReactiveCommand<Unit, Unit> CloseCmd  { get; }
        public ReactiveCommand<Unit, Unit> EscapeCmd { get; }

        public ViewNode(TabViewModelBase vm, ViewNode? parent = null)
        {
            _viewModel = vm;
            _parent    = parent;
            SwitchCmd  = ReactiveCommand.Create(OnSwitch);
            CloseCmd   = ReactiveCommand.Create(OnClose);
            EscapeCmd  = ReactiveCommand.Create(OnEscape);
        }

        public virtual void OnSwitch()
        {

        }

        public virtual void OnClose()
        {

        }

        public virtual void OnEscape()
        {

        }
        
        public virtual void AddChild(ViewNode child)
        {
            Childs.Add(child);
            child.Parent = this;
        }

        public virtual void RemoveChild(ViewNode child)
        {
            child.Parent = null;
            Childs.Remove(child);
        }
    }
}
