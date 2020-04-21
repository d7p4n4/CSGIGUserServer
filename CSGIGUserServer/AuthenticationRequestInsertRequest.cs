using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGUserServer
{
    public class AuthenticationRequestInsertRequest : Ac4yServiceRequest
    {
        public AuthenticationRequest AuthenticationRequest { get; set; }
    }
}
