using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.UI.ViewModels.Base
{
    public class ViewModelBase<T> : ViewModelBase
    {
        private T model;

        public T Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
                this.RaisePropertyChanged(() => this.Model);
            }
        }
       
    }
}
