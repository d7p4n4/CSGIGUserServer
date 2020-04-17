using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGUserServer
{
    public class AttachNewDeviceRequest : Ac4yServiceRequest
    {
        public UserToken UserToken { get; set; }
    }
}
