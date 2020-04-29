using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGUserServer
{
    public class UpdateUserByGuidRequest : Ac4yServiceRequest
    {
        public string UserGuid { get; set; }
        public User User { get; set; }
    }
}
