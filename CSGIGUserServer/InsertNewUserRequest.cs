using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGUserServer
{
    public class InsertNewUserRequest : Ac4yServiceRequest
    {
        public User User { get; set; }
    }
}
