using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGUserServer
{
    public class AuthenticationRequestUpdateRequest : Ac4yServiceRequest
    {
        public string UserGuid { get; set; }
        public string CheckData { get; set; }
    }
}
