﻿using Modul.Final.Class;
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

                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "létezik" };

                    foreach (var token in tokenList)
                    {
                        if (request.fbToken.Equals(token.fbToken))
                        {
                            response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "a token már a userhez van rendelve" };
                        }
                    }
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

        public AttachNewDeviceResponse AttachNewDevice(AttachNewDeviceRequest request)
        {
            AttachNewDeviceResponse response = new AttachNewDeviceResponse();

            try
            {
                new EFUserTokenMethodsCAP().Insert(request.UserToken);

                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "Sikeres insert" };
                
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }

        public AuthenticationRequestResponse AuthenticationRequestInsert(AuthenticationRequestRequest request)
        {
            AuthenticationRequestResponse response = new AuthenticationRequestResponse();

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

        public AuthenticationRequestGetByGuidResponse GetUserGuidByToken(AuthenticationRequestGetByGuidRequest request)
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
    }
}
