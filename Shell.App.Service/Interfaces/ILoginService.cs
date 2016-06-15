using System.Runtime.Serialization;
using System.ServiceModel;

namespace Shell.App.Service.Interfaces
{
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        LoginData GetLoginData();
    }

    [DataContract]
    public class LoginData
    {
        bool boolValue = true;
        string stringValue = "Hello ";
        string stringValue2 = "MamkyEbal";
        string stringValue3 = "Твою";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
