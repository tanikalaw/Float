using DataAccess;
using Float.BaseModel;
using Float.Command;
using Float.Component.Dashboard;
using Float.Component.Login;
using Float.DataModels;
using Float.GenericErrorMessage;
using Float.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Float.Components.Login
{
    public class LoginViewModel : BaseViewModel
    {
        LoginView loginView;
        GenericErrorMessageViewModel window = new GenericErrorMessageViewModel();
        public LoginViewModel()
        {
            Initialize();
            HttpClientHelper.InitializeClient();
        }

        private LoginModel loginModel;
        public LoginModel LoginModel
        {
            get { return loginModel; }

            set
            {
                loginModel = value;
                RaisedPropertyChanged(nameof(LoginModel));
            }
        }

        private bool isSignUpClicked;
        public bool IsSignUpClicked
        {
            get { return isSignUpClicked; }
            set
            {
                isSignUpClicked = value;
                RaisedPropertyChanged(nameof(IsSignUpClicked));
            }
        }

        #region Commands 

        public ICommand SignUpCommand
        {
            get
            {
                return new DelegateCommand<PasswordBox>(SignUp);
            }
        }

        public ICommand SignInCommand
        {
            get
            {
                return new DelegateCommand<PasswordBox>(SignIn);
            }
        }

        public ICommand UserLoginCommand
        {
            get
            {
                return new DelegateCommand(UserLogin);
            }
        }

        public ICommand UserSignUpCommand
        {
            get
            {
                return new DelegateCommand<object>(UserSignUp);
            }
        }

        public ICommand OnUserPasswordChangeCommand
        {
            get
            {
                return new DelegateCommand<PasswordBox>(loginModel.OnUserPasswordChanged);
            }
        }

        public ICommand EnterCommandToChooseCommand
        {
            get
            {
                return new DelegateCommand<object[]>(EnterCommandToChoose);
            }
        }
        #endregion

        #region Methods

        private void Initialize()
        {
            loginModel = new LoginModel();
        }

        private void SignUp(PasswordBox passwordBox)
        {
            passwordBox.Clear();
            IsSignUpClicked = true;
            ClearFields();
        }

        private void SignIn(PasswordBox passwordBox)
        {
            IsSignUpClicked = false;
            passwordBox.Clear();
            ClearFields();
        }


        private void UserLogin()
        {
            var isEmpty = ValidateFields(LoginModel.UserUsername, LoginModel.UserPassword);

            if (!isEmpty)
                return;

            MemberService memberService = new MemberService();
            bool result = memberService.SearchMember(LoginModel.UserUsername, LoginModel.UserPassword);


            ClearFields();

            MainDashboard mainDashboard = new MainDashboard();
            App.Current.MainWindow.Close();
            mainDashboard.Owner = App.Current.MainWindow;

            mainDashboard.ShowDialog();
        }

        private async void UserSignUp(object parameter)
        {
            PasswordBox passwordBox = parameter as PasswordBox;
            MemberService memberService = new MemberService();
            SignupDataModel signup = new SignupDataModel();

            signup.Username = LoginModel.UserUsername;
            signup.Password = LoginModel.UserPassword;

            try
            {
                var result = await memberService.RegisterUserAsync(signup);

                GenericErrorMessageView genericWindow = new GenericErrorMessageView();
                genericWindow.Owner = App.Current.MainWindow;

                genericWindow.Show();
            }
            catch (Exception ex)
            {
                GenericErrorMessageView genericWindow = new GenericErrorMessageView();
                GenericErrorMessageViewModel genericErrorMessageViewModel = new GenericErrorMessageViewModel();
                genericErrorMessageViewModel.ErrorMessage = ex.Message;
                genericWindow.ShowDialog();
            }
            passwordBox?.Clear();
            loginModel.UserUsername = string.Empty;
        }

        private void ClearFields()
        {
            loginModel.UserUsername = string.Empty;
        }

        private void EnterCommandToChoose(object[] pb)
        {
            UserLogin();
            //if (IsSignUpClicked)
            //    //UserSignUp();
            //else

            for (int i = 0; i < pb.Length; i++)
            {
                PasswordBox pass = (PasswordBox)pb[i];
                pass.Clear();
            }
        }

        private bool ValidateFields(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;
            else
                return true;
        }

        #endregion
    }
}
