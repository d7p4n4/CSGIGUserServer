using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGUserServer
{
    public class AuthenticationRequestGetByGuidResponse : Ac4yServiceResponse
    {
        public AuthenticationRequest AuthenticationRequest { get; set; }
    }
}
