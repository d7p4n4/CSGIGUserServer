using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGUserServer
{
    public class CheckSerialNumberRequest : Ac4yServiceRequest
    {
        public int SerialNumber { get; set; }
    }
}
