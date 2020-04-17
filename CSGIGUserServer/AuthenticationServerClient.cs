using Modul.Final.Class;
using Newtonsoft.Json;
using SycomplaWebAppClientCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGIGUserServer
{
    public class AuthenticationServerClient
    {
        public string Server { get; set; }
        public string ServerKey { get; set; }

        public AuthenticationServerClient() { }

        public AuthenticationServerClient(string server, string serverKey)
        {
            Server = server;
            ServerKey = serverKey;
        }

        public AuthenticatioRequestResponse AuthenticatioRequest(AuthenticatioRequestRequest request)
        {
            AuthenticatioRequestResponse response = new AuthenticatioRequestResponse();

            try{
                new Ac4yRestServiceClient(Server, ServerKey).POST("", "{\r\n \"to\" : \"" + request.fbToken + "\",\r\n\r\n \"data\" : {\r\n\r\n } \r\n}");

                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }
        
    }
}
