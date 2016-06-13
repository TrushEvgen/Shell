using Shell.Core;
using System.Security;
using System.Windows.Input;

namespace Shell.App.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Fields

        //private ILoginService loginService;

        #endregion

        #region Constructor

        public LoginViewModel()
        {
            //loginService = ShellService.Instance as ILoginService;

            LoginCommand = new RelayCommand(Login, x => CanLogin());

            Username = string.Empty;
            Password = new SecureString();
            Remember = false;

#if DEBUG
            Username = "Admin";

            Login();
#endif
        }

        #endregion

        #region Property

        public string Username
        {
            get { return Get<string>("Username"); }
            set { Set(value, "Username"); }
        }

        public SecureString Password
        {
            get { return Get<SecureString>("Password"); }
            set { Set(value, "Password"); }
        }

        public bool Remember
        {
            get { return Get<bool>("Remember"); }
            set { Set(value, "Remember"); }
        }

        public bool? DialogResult
        {
            get { return Get<bool?>("DialogResult"); }
            set { Set(value, "DialogResult"); }
        }

        //public LoginSettings LoginSettings
        //{
        //    get { return Get<LoginSettings>("LoginSettings"); }
        //    set { Set(value, "LoginSettings"); }
        //}

        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }

        #endregion

        #region Methods

        private bool CanLogin()
        {
            return (!Username.Equals(string.Empty));
        }

        private void Login()
        {
            //if (loginService.Login(Username, Password, out LoginSettings))
            //{
            //    DialogResult = true;
            //}
            //else
            //{
            //    DialogResult = false;
            //}
        }

        #endregion
    }
}
