using Modul.Final.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGIGUserServer
{
    public class UserServerObjectService
    {

        public IsUnknownOrInvalidTokenResponse IsUnknownOrInvalidToken(IsUnknownOrInvalidTokenRequest request)
        {
            IsUnknownOrInvalidTokenResponse response = new IsUnknownOrInvalidTokenResponse();

            try
            {
                if (new EFUserTokenMethodsCAP().IsExistByFBToken(request.fbToken))
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "létezik a token a db-ben" };
                }
                else
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "unknown or invalid token" };
                }
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }

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
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "nem létezik" };
                }
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }

        public CheckSerialNumberResponse CheckSerialNumber(CheckSerialNumberRequest request)
        {
            CheckSerialNumberResponse response = new CheckSerialNumberResponse();

            try
            {
                if (new EFUserMethodsCAP().IsExistById(request.SerialNumber))
                {
                    User user = new EFUserMethodsCAP().GetById(request.SerialNumber);
                    List<UserToken> tokenList = new EFUserTokenMethodsCAP().GetListByGuid(user.Guid);

                    response.UserGuid = user.Guid;
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "létezik az adott serial number" };

                    foreach (var token in tokenList)
                    {
                        if (request.fbToken.Equals(token.fbToken))
                        {
                            response.UserGuid = null;
                            response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "a token már a userhez van rendelve" };
                        }
                    }
                }
                else
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "nem létezik az adott serial number" };
                }
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }

        public AttachNewDeviceResponse AttachNewDevice(AttachNewDeviceRequest request)
        {
            AttachNewDeviceResponse response = new AttachNewDeviceResponse();

            try
            {
                IsExistTokenByTokenResponse isExistTokenByTokenResponse =
                    new UserServerObjectService().IsExistTokenByToken(new IsExistTokenByTokenRequest()
                    {
                        fbToken = request.UserToken.fbToken
                    });

                if (isExistTokenByTokenResponse.Result.Success())
                {

                    new EFUserTokenMethodsCAP().UpdateByFbToken(request.UserToken);

                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "Sikeres update" };
                }
                else
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "nem létezik a token a db-ben" };
                }

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }

        public AuthenticationRequestInsertResponse AuthenticationRequestInsert(AuthenticationRequestInsertRequest request)
        {
            AuthenticationRequestInsertResponse response = new AuthenticationRequestInsertResponse();

            try
            {
                new EFAuthenticationRequestMethodsCAP().Insert(request.AuthenticationRequest);

                response.AuthenticationRequest = request.AuthenticationRequest;
                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "Sikeres insert" };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;

        }

        public AuthenticationRequestGetByGuidResponse AuthenticationRequestGetByGuid(AuthenticationRequestGetByGuidRequest request)
        {
            AuthenticationRequestGetByGuidResponse response = new AuthenticationRequestGetByGuidResponse();

            try
            {
                if (new EFAuthenticationRequestMethodsCAP().IsExistByGuid(request.Guid))
                {
                    AuthenticationRequest authenticationRequest = new EFAuthenticationRequestMethodsCAP().GetByGuid(request.Guid);

                    response.AuthenticationRequest = authenticationRequest;
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "létezik" };
                }
                else
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "nem létezik" };
                }
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }

        public InsertNewUserResponse InsertNewUser(InsertNewUserRequest request)
        {
            InsertNewUserResponse response = new InsertNewUserResponse();

            try
            {
                new EFUserMethodsCAP().Insert(request.User);
                
                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "Sikeres user insert" };
                
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;

        }

        public GetUserByTokenResponse GetUserByToken(GetUserByTokenRequest request)
        {
            GetUserByTokenResponse response = new GetUserByTokenResponse();

            try
            {
                UserToken userToken = new EFUserTokenMethodsCAP().GetByFBToken(request.fbToken);

                User user = new EFUserMethodsCAP().GetByGuid(userToken.UserGuid);
                response.User = user;
                response.Json = JsonConvert.SerializeObject(user);
                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "Megvan a tokenhez tartozó user" };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;

        }

        public InsertNewTokenResponse InsertNewToken(InsertNewTokenRequest request)
        {
            InsertNewTokenResponse response = new InsertNewTokenResponse();

            try
            {
                new EFUserTokenMethodsCAP().Insert(request.UserToken);
                
                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "Sikeres Token insert" };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;

        }

        public IsExistTokenByTokenResponse IsExistTokenByToken(IsExistTokenByTokenRequest request)
        {
            IsExistTokenByTokenResponse response = new IsExistTokenByTokenResponse();

            try
            {
                if(new EFUserTokenMethodsCAP().IsExistByFBToken(request.fbToken))
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "Már létezik a token" };
                else
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "Még nem létezik a token" };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;

        }

        public isExistByGuidResponse IsExistByGuid(isExistByGuidRequest request)
        {
            isExistByGuidResponse response = new isExistByGuidResponse();

            try
            {
                if (new EFAuthenticationRequestMethodsCAP().IsExistByGuid(request.Guid))
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "Már létezik ezzel a guid-al rekord" };
                else
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "Még nem létezik ezzel a guid-al rekord" };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;

        }

        public DeleteUserResponse DeleteUser(DeleteUserRequest request)
        {
            DeleteUserResponse response = new DeleteUserResponse();

            try
            {
                UserToken userToken = new EFUserTokenMethodsCAP().GetByFBToken(request.fbToken);

                if (userToken != null)
                {
                    User user = new EFUserMethodsCAP().GetByGuid(userToken.UserGuid);
                    response.UserGuid = user.Guid;

                    if(user != null)
                    {
                        new EFUserMethodsCAP().DeleteUser(user);

                        response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "user törölve" };
                    }
                    else
                        response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "a usert nem sikerült kiolvasni" };
                }
                else
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "ezzel a tokennel nincs user-token pár" };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;


        }

        public DeleteAuthenticationRequestResponse DeleteAuthenticationRequest(DeleteAuthenticationRequestRequest request)
        {
            DeleteAuthenticationRequestResponse response = new DeleteAuthenticationRequestResponse();

            try
            {
                AuthenticationRequest authenticationRequest = new EFAuthenticationRequestMethodsCAP().GetByGuid(request.UserGuid);

                if (authenticationRequest != null)
                {
                    new EFAuthenticationRequestMethodsCAP().DeleteAuthenticationRequest(authenticationRequest);

                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "authentication request törölve" };
                }
                else
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "nem létezik az adott guid-hoz authentication request" };
                
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;


        }

        public AuthenticationRequestUpdateResponse UpdateAuthenticationRequest(AuthenticationRequestUpdateRequest request)
        {
            AuthenticationRequestUpdateResponse response = new AuthenticationRequestUpdateResponse();

            try
            {
                AuthenticationRequest authenticationRequest = new EFAuthenticationRequestMethodsCAP().UpdateByGuid(request.UserGuid, request.CheckData);

                if (authenticationRequest != null)
                {
                    response.AuthenticationRequest = authenticationRequest;

                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "authentication request törölve" };
                }
                else
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "nem létezik az adott guid-hoz authentication request" };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;


        }

        public UpdateUserByGuidResponse UpdateUserByGuid(UpdateUserByGuidRequest request)
        {
            UpdateUserByGuidResponse response = new UpdateUserByGuidResponse();

            try
            {
                    new EFUserMethodsCAP().UpdateByGuid(request.UserGuid, request.User);

                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "user adatai frissítve" };
               
            }
            catch (Exception exception)
           {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;


        }

        public GetListOfUsersResponse GetListOfUsers(GetListOfUsersRequest request)
        {
            GetListOfUsersResponse response = new GetListOfUsersResponse();

            try
            {
                response.Users = new EFUserMethodsCAP().GetListOfUsers();
                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "user lista kiolvasva" };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;


        }

        public DeleteUserByIdResponse DeleteUserById(DeleteUserByIdRequest request)
        {
            DeleteUserByIdResponse response = new DeleteUserByIdResponse();

            try
            {
                new EFUserMethodsCAP().DeleteUserById(request.Id);
                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "user törölve" };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }

        public UpdateUserByIdResponse UpdateUserById(UpdateUserByIdRequest request)
        {
            UpdateUserByIdResponse response = new UpdateUserByIdResponse();

            try
            {
                new EFUserMethodsCAP().UpdateById(request.Id, request.User);

                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "user adatai frissítve" };


            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;


        }
    }

    }
