using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Conduit.Mobile.Contracts;

namespace SMP_RegistrationService.Contracts
{
    [ServiceContract]    
    public interface IRegistrationManager
    {
        [OperationContract]
        Response<bool> Register(string provider, string user, string pw);

        [OperationContract]
        Response<bool> CompleteRegistration(string url);
    }
}
