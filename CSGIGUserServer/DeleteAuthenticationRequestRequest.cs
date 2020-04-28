using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGUserServer
{
    public class DeleteAuthenticationRequestRequest : Ac4yServiceRequest
    {
        public string UserGuid { get; set; }
    }
}
