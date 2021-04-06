using DataAccess;
using Float.BaseModel;
using Float.Command;
using Float.Component.Dashboard;
using Float.DataModels;
using Float.GenericMessages;
using Float.Model;
using Float.Services;
using Float.ViewModelMediator;
using System;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;

namespace Float.Components.Login
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {

            InitializeMembers();
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

        private void InitializeMembers()
        {
            loginModel = new LoginModel();

            Mediator.Instance.Register(this, MediatorMessages.LoginViewModel);

            HttpClientHelper.InitializeClient();
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


        private async void UserLogin()
        {
            var isEmpty = ValidateFields(LoginModel.UserUsername, LoginModel.UserPassword);

            if (!isEmpty)
                return;

            MemberServiceProvider memberService = new MemberServiceProvider();
            UserAccountModel userAccountModel = new UserAccountModel();
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            userAccountModel.Username = LoginModel.UserUsername;
            userAccountModel.Password = LoginModel.UserPassword;
            try
            {
                var result = await memberService.AuthenticateUserAsync(userAccountModel, cancellationTokenSource.Token);

                if (result != null)
                {
                    MainDashboard mainDashboard = new MainDashboard();
                    App.Current.MainWindow.Close();

                    mainDashboard.Owner = App.Current.MainWindow;

                    mainDashboard.ShowDialog();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                ShowGenericMessage(ex.Message);
            }
        }

        private async void UserSignUp(object parameter)
        {
            PasswordBox passwordBox = parameter as PasswordBox;
            MemberServiceProvider memberService = new MemberServiceProvider();
            SignupModel signup = new SignupModel();
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            signup.Username = LoginModel.UserUsername;
            signup.Password = LoginModel.UserPassword;

            try
            {
                var signupDataModel = await memberService.RegisterUserAsync(signup, cancellationTokenSource.Token);

                if(signupDataModel != null)
                {
                    GenericMessageView view = new GenericMessageView();
                    Mediator.Instance.NotifyViewModel(MediatorMessages.GenericMessageViewModel, MediatorMessages.GenericMessageView, view);
                    Mediator.Instance.NotifyViewModel(MediatorMessages.GenericMessageViewModel, MediatorMessages.GenericMessage, "Successfuly created your account.");
                    view.Owner = App.Current.MainWindow;
                    view.ShowDialog();

                }

            }
            catch (Exception ex)
            {
                ShowGenericMessage(ex.Message);
            }
            //passwordBox?.Clear();
            //loginModel.UserUsername = string.Empty;
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
