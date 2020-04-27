using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGUserServer
{
    public class DeleteUserRequest : Ac4yServiceRequest
    {
        public string fbToken { get; set; }
    }
}
