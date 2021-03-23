using Float.BaseModel;
using System.Linq;
using System.Windows.Controls;

namespace Float.Components.Login
{
    public class LoginModel : BaseViewModel
    {

        public LoginModel()
        {
            UserUsername = string.Empty;

            UserPassword = string.Empty;
        }

        private string userUsername;
        public string UserUsername
        {
            get
            { return userUsername; }
            set
            {
                userUsername = value;
                RaisedPropertyChanged(nameof(UserUsername));
                ValidateFields();
            }

        }

        private string userPassword;
        public string UserPassword
        {
            get
            { return userPassword; }
            set
            {
                userPassword = value;
                RaisedPropertyChanged(nameof(UserPassword));
                ValidateFields();
            }
        }

        private bool hasMetRequirements;
        public bool HasMetRequirements
        {
            get
            { return hasMetRequirements; }
            set
            {
                hasMetRequirements = value;
                RaisedPropertyChanged(nameof(HasMetRequirements));
            }
        }

        public void OnUserPasswordChanged(object parameter)
        {
           PasswordBox passwordBox = (PasswordBox)parameter;
            if (passwordBox.Password == string.Empty)
            {
                passwordBox.Tag = "Enter Password";
                passwordBox.Password = string.Empty;
            }
            else
                passwordBox.Tag = string.Empty;

            UserPassword = passwordBox.Password;
        }

        private void ValidateFields()
        {
            if(UserUsername != null && UserPassword != null)
            {
                if (UserUsername.Count() >= 6 && UserPassword.Count() >= 6)
                    HasMetRequirements = true;
                else
                    HasMetRequirements = false;
            }
        }
    }
}
