﻿using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGIGUserServer
{
    public class GetByIdRequest : Ac4yServiceRequest
    {
        public int id { get; set; }
    }
}
