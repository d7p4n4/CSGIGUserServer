using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGIGUserServer
{
    public class InsertRequest : Ac4yServiceRequest
    {

        public User User { get; set; }
    }
}
