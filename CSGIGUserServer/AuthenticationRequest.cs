using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGUserServer
{
    public class AuthenticationRequest
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string CheckData { get; set; }
    }
}
