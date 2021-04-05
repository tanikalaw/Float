using Float.GenericMessages;
using Float.ViewModelMediator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Float.BaseModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void SendData(string message, object args) { }

        protected void RaisedPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public async Task ShowGenericMessage(object parameter)
        {
            GenericErrorMessageView genericErrorMessageView = new GenericErrorMessageView();

            genericErrorMessageView.Owner = App.Current.MainWindow;

            Mediator.Instance.NotifyViewModel(MediatorMessages.GenericErrorViewModel, MediatorMessages.GenericErrorViewModelErrorMessage, parameter);
            Mediator.Instance.NotifyViewModel(MediatorMessages.GenericErrorViewModel, MediatorMessages.GenericErrorWindow, genericErrorMessageView);
            genericErrorMessageView.ShowDialog();
        }
    }
}
