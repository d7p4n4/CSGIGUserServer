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
                fbToken = "123456789"
            });
            

            AuthenticationRequestResponse authenticationRequestResponse =
                new UserServerObjectService().AuthenticationRequestInsert(new AuthenticationRequestRequest()
                {
                    AuthenticationRequest = new AuthenticationRequest()
                    {
                        Guid = "9584b9f730c2b88889f36a4560f49d8ad1a5f280cbf0f416e4f332c2a9b051c1ddb55f2a09e86a2748224e2f5b1270b941dfbe2ba4447adb09aa9592a5e2984d",
                        CheckData = "1234"
                    }
                });

            /*
            GetUserGuidByFBTokenResponse getUserGuidByFBTokenResponse =
                    new UserServerObjectService().GetUserGuidByToken(new GetUserGuidByFBTokenRequest()
                    {
                        fbToken = "123456"
                    });
                    
            
            CheckSerialNumberResponse checkSerialNumberResponse =
                new UserServerObjectService().CheckSerialNumber(new CheckSerialNumberRequest()
                {
                    SerialNumber = 1,
                    fbToken = "12345677"
                });
                
            
            AttachNewDeviceResponse attachNewDeviceResponse =
                new UserServerObjectService().AttachNewDevice(new AttachNewDeviceRequest()
                {
                    UserToken = new UserToken()
                    {
                        UserGuid = "ujabbTesztGuid",
                        fbToken = "1234567"
                    }
                });*/

            AuthenticationRequestGetByGuidResponse AuthenticationRequestGetByGuidResponse =
                new UserServerObjectService().AuthenticationRequestGetByGuid(new AuthenticationRequestGetByGuidRequest()
                {
                    Guid = "9584b9f730c2b88889f36a4560f49d8ad1a5f280cbf0f416e4f332c2a9b051c1ddb55f2a09e86a2748224e2f5b1270b941dfbe2ba4447adb09aa9592a5e2984d"
                });
        }
    }
}
