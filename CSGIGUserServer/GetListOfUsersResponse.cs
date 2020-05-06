using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGUserServer
{
    public class GetListOfUsersResponse : Ac4yServiceResponse
    {
        public List<User> Users { get; set; }
    }
}
