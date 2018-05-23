using System;
using System.Collections.Generic;
using System.Text;

namespace AEREnigma.ViewModels
{
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Messaging;

    public abstract class AdaViewModelBase<T> : ViewModelBase
    {
        private T model;

        protected AdaViewModelBase()
        {
        }

        protected AdaViewModelBase(IMessenger messenger) : base(messenger)
        {
        }

        protected AdaViewModelBase(object initData)
        {
            this.Init(initData);
        }


        public T Model
        {
            get
            {
                return this.model;
            }

            set
            {
                this.Model = value;
                this.RaisePropertyChanged();
            }
        }

        public override void RaisePropertyChanged<T>(
            [CallerMemberName] string propertyName = null,
            T oldValue = default(T),
            T newValue = default(T),
            bool broadcast = false)
        {
            base.RaisePropertyChanged(propertyName, oldValue, newValue, broadcast);

            this.OnPropertyChanged(propertyName);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {

        }

        protected abstract Task Initialize(object initData);

        private void Init(object initData)
        {
            this.Initialize(initData);
        }
    }
}
