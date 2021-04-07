using Float.GenericMessages;
using Float.ViewModelMediator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Float.BaseModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void SendData(string message, object args) { }

        protected void RaisedPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public async Task ShowGenericMessage(object parameter)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                GenericDialogView genericErrorMessageView = new GenericDialogView();

                genericErrorMessageView.Owner = App.Current.MainWindow;
                Mediator.Instance.NotifyViewModel(MediatorMessages.GenericDialogViewModel, MediatorMessages.GenericDialogView, genericErrorMessageView);
                Mediator.Instance.NotifyViewModel(MediatorMessages.GenericDialogViewModel, MediatorMessages.GenericDialogMessage, parameter);
                Mediator.Instance.NotifyViewModel(MediatorMessages.GenericDialogViewModel, MediatorMessages.GenericDialogError);
                genericErrorMessageView.ShowDialog();
            });
        }
    }
}
