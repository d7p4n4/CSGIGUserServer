﻿using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGUserServer
{
    public class GetUserByTokenResponse : Ac4yServiceResponse
    {
        public User User { get; set; }
        public string Json { get; set; }
    }
}
