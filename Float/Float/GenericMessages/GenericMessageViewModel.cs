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
    public class GenericMessageViewModel : BaseViewModel
    {
        GenericMessageView view;

        public GenericMessageViewModel()
        {
            Mediator.Instance.Register(this, MediatorMessages.GenericMessageViewModel);
        }

        public override void SendData(string message, object args)
        {
            switch (message)
            {
                case MediatorMessages.GenericMessageView:
                    view = (GenericMessageView)args;
                    break;
                case MediatorMessages.GenericMessage:
                    GenericMessage = (string)args;
                    break;
                default:
                    break;
            }
        }

        public ICommand CloseWindowCommand => new DelegateCommand(CloseWindow);
      

        private string genericMessage;
        public string GenericMessage 
        {
            get { return genericMessage; }
            set
            {
                genericMessage = value;
                RaisedPropertyChanged(nameof(GenericMessage));
            }
        }

        private void CloseWindow()
        {
            Mediator.Instance.Unregister(this, MediatorMessages.GenericMessageViewModel);
            view.Close();
        }
    }
}
