using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGIGUserServer
{
    public class UserServerObjectService
    {

        public GetUserGuidByFBTokenResponse GetUserGuidByToken(GetUserGuidByFBTokenRequest request)
        {
            GetUserGuidByFBTokenResponse response = new GetUserGuidByFBTokenResponse();

            try
            {
                if (new EFUserTokenMethodsCAP().IsExistByFBToken(request.fbToken))
                {
                    UserToken user = new EFUserTokenMethodsCAP().GetByFBToken(request.fbToken);

                    response.UserGuid = user.UserGuid;
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "létezik" };
                }
                else
                {
                    response.UserGuid = "hibás";
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "nem létezik" };
                }
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }
    }
}
