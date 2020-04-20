using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGUserServer
{
    public class AuthenticationRequestGetByGuidRequest : Ac4yServiceRequest
    {
        public string Guid { get; set; }
    }
}
