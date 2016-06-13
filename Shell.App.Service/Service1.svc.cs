using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Shell.App.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        //private byte[] CreateHash(string username, SecureString password)
        //{
        //    string pwd = ConvertToUnsecureString(password);

        //    pwd.IndexOf(username, pwd.Length % 2);

        //    byte[] input = Encoding.UTF8.GetBytes(pwd);

        //    SHA256 sha256 = SHA256.Create();

        //    byte[] hash = sha256.ComputeHash(input);

        //    return hash;
        //}

        //public string ConvertToUnsecureString(SecureString secstrPassword)
        //{
        //    IntPtr unmanagedString = IntPtr.Zero;
        //    try
        //    {
        //        unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secstrPassword);
        //        return Marshal.PtrToStringUni(unmanagedString);
        //    }
        //    finally
        //    {
        //        Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
        //    }
        //}

        //public bool Login(string username, SecureString password, out LoginSettings loginSettings)
        //{
        //    byte[] hash = CreateHash(username, password);

        //    loginSettings = new LoginSettings()
        //    {
        //        MenuItems = new List<MenuItem>()
        //        {
        //            new MenuItem()
        //            {
        //                Header = "File",
        //                MenuItems = new List<MenuItem>()
        //                {
        //                    new MenuItem()
        //                    {
        //                        Header = "Open Log"
        //                    },
        //                    new MenuItem()
        //                    {
        //                        Header = "Exit",
        //                        Command = new CommandParameter()
        //                        {
        //                            Assembly = "Shell.App",
        //                            Type = "Shell.App.App",
        //                            Method = "Shutdown",
        //                        }
        //                    }
        //                }
        //            },
        //            new MenuItem()
        //            {
        //                Header = "Documents",
        //                MenuItems = new List<MenuItem>()
        //                {
        //                    new MenuItem()
        //                    {
        //                        Header = "All tenders"
        //                    }
        //                }
        //            }
        //        }
        //    };

        //    return true;
        //}
    }
}
