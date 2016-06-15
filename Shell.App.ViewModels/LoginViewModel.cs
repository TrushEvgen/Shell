using System;
using System.Security;
using System.Windows.Input;
using Shell.App.ViewModels.ServiceReference;
using Shell.Core;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace Shell.App.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Fields

        #endregion

        #region Constructor

        public LoginViewModel()
        {
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

        public LoginData LoginData { get; private set; }

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
            LoginServiceClient client = null;

            try
            {
                client = new LoginServiceClient();
                client.ClientCredentials.UserName.UserName = Username;
                client.ClientCredentials.UserName.Password = CreateHash(Username, Password);

                LoginData = client.GetLoginData();

                DialogResult = true;
            }
            catch (Exception ex)
            {
                
            }
            finally 
            {
                if (client != null)
                {
                    client.Close();
                }
            }
        }

        private string CreateHash(string username, SecureString password)
        {
            string pwd = ConvertToUnsecureString(password);

            pwd.IndexOf(username, pwd.Length % 2);

            byte[] input = Encoding.UTF8.GetBytes(pwd);

            SHA256 sha256 = SHA256.Create();

            byte[] hash = sha256.ComputeHash(input);

            string result = Encoding.UTF8.GetString(hash);

            return result;
        }

        private string ConvertToUnsecureString(SecureString secstrPassword)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secstrPassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        #endregion
    }
}
