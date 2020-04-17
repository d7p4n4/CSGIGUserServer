using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGUserServer
{
    class Program
    {
        public static void Main(String[] args)
        {/*
            new EFUserMethodsCAP().Insert(new User()
            {
                Guid = "tesztguid",
                FBToken = "123456"
            });

            new EFUserTokenMethodsCAP().Insert(new UserToken()
            {
                UserGuid = "tesztguid",
                fbToken = "123456"
            });

            GetUserGuidByFBTokenResponse getUserGuidByFBTokenResponse =
                    new UserServerObjectService().GetUserGuidByToken(new GetUserGuidByFBTokenRequest()
                    {
                        fbToken = "123456"
                    });
                    */

            CheckSerialNumberResponse checkSerialNumberResponse =
                new UserServerObjectService().CheckSerialNumber(new CheckSerialNumberRequest()
                {
                    SerialNumber = 5
                });
        }
    }
}
