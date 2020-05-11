using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGUserServer
{
    public class UpdateUserByIdRequest : Ac4yServiceRequest
    {
        public int Id { get; set; }
        public User User { get; set; }
    }
}
