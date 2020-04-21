using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGUserServer
{
    public class GetUserByTokenRequest : Ac4yServiceResponse
    {
        public string fbToken { get; set; }
    }
}
