using Float.BaseModel;
using Float.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Float.GenericErrorMessage
{
   public class GenericErrorMessageViewModel : BaseViewModel
    {
        public GenericErrorMessageViewModel()
        {

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
            window.Close();
        }
    }
}
