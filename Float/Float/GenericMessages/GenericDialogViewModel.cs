using Float.BaseModel;
using Float.Command;
using Float.ViewModelMediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Float.GenericMessages
{
    public class GenericDialogViewModel : BaseViewModel
    {
        GenericDialogView view;

        public GenericDialogViewModel()
        {
            Mediator.Instance.Register(this, MediatorMessages.GenericDialogViewModel);
        }

        public override void SendData(string message, object args)
        {
            switch (message)
            {
                case MediatorMessages.GenericDialogView:
                    view = (GenericDialogView)args;
                    break;
                case MediatorMessages.GenericDialogMessage:
                    Message = (string)args;
                    break;


                default:
                    break;
            }
        }

        public ICommand CloseWindowCommand => new DelegateCommand(CloseWindow);
      

        private string message;
        public string Message 
        {
            get { return message; }
            set
            {
                message = value;
                RaisedPropertyChanged(nameof(Message));
            }
        }

        private bool isError;
        public bool IsError
        {
            get { return isError; }
            set
            {
                isError = value;
                RaisedPropertyChanged(nameof(IsError));
            }
        }

        private bool isSuccess;
        public bool IsSuccess
        {
            get { return isSuccess; }
            set
            {
                isSuccess = value;
                RaisedPropertyChanged(nameof(IsSuccess));
            }
        }

        private void CloseWindow()
        {
            Mediator.Instance.Unregister(this, MediatorMessages.GenericDialogViewModel);
            view.Close();
        }
    }
}
