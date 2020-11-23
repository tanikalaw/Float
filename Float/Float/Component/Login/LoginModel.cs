using simpleCRUD.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void OnUserPasswordChanged(PasswordBox passwordBox)
        {
            if (passwordBox.Password == string.Empty)
                passwordBox.Tag = "Enter Password";
            else
                passwordBox.Tag = string.Empty;


            UserPassword = passwordBox.Password;
        }

        private void ValidateFields()
        {
            if(UserUsername != null && UserPassword != null)
            {
                if (UserUsername.Count() >= 6)
                    HasMetRequirements = true;

                if (UserPassword.Count() >= 6)
                    HasMetRequirements = true;
                else
                    HasMetRequirements = false;
            }
        }
    }
}
