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
    public class GenericErrorMessageViewModel : BaseViewModel
    {
        public GenericErrorMessageViewModel()
        {
            Mediator.Instance.Register(this, MediatorMessages.GenericErrorViewModel);
        }

        public override void SendData(string message, object args)
        {
            switch (message)
            {
                case MediatorMessages.GenericErrorWindow:
                    window = (GenericErrorMessageView)args;
                    break;
                
                case MediatorMessages.GenericErrorViewModelErrorMessage:
                    ErrorMessage = (string)args;
                    break;
            }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                RaisedPropertyChanged(nameof(ErrorMessage));
            }
        }
        public GenericErrorMessageView window { get; set; }

        public ICommand CloseWindowCommand => new DelegateCommand(CloseWindow);

        public void CloseWindow()
        {
            Mediator.Instance.Unregister(this, MediatorMessages.GenericErrorViewModel);
            window.Close();

        }
    }
}
