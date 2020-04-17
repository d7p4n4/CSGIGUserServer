using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGIGUserServer
{
    public class UserToken
    {
        public int id { get; set; }
        public string UserGuid { get; set; }
        public string fbToken { get; set; }
    }
}
