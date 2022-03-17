using Shared.Models;
using Shared.Tools;

namespace Shared.Models{


    public class Request{

        public UserCredentials Credentials{get;set;}
        public RequestTypes RequestTypes{get;set;}
        public Request(UserCredentials? credentials = null,RequestTypes requestTypes = RequestTypes.LOGIN)
        {
            Credentials = credentials;
            RequestTypes = requestTypes;
        }

    }
}