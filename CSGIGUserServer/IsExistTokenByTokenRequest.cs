using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGUserServer
{
    public class IsExistTokenByTokenRequest : Ac4yServiceRequest
    {
        public string fbToken { get; set; }
    }
}
