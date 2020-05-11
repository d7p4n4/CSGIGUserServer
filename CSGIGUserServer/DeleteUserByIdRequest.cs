using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGUserServer
{
    public class DeleteUserByIdRequest : Ac4yServiceRequest
    {
        public int Id { get; set; }
    }
}
