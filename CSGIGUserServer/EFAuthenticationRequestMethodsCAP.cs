using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGIGUserServer
{
    public class EFAuthenticationRequestMethodsCAP
    {

        public AuthenticationRequest Insert(AuthenticationRequest request)
        {

            using (var ctx = new Context())
            {
                ctx.Database.EnsureCreated();

                ctx.Requestek.Add(request);
                ctx.SaveChanges();
            }

            return request;

        }

        public AuthenticationRequest GetById(int id)
        {
            return new Context().Requestek.Find(id);
        }

        public bool IsExistById(int id)
        {
            return GetById(id) != null;
        }

        public AuthenticationRequest GetByGuid(string guid)
        {
            return new Context().Requestek
                    .Where(entity => entity.Guid == guid)
                    .FirstOrDefault<AuthenticationRequest>();
        } // GetByGuid

        public bool IsExistByGuid(string guid)
        {

            return GetByGuid(guid) != null;

        }

        public AuthenticationRequest GetByCheckData(string checkData)
        {

            return new Context().Requestek
                      .Where(entity => entity.CheckData == checkData)
                      .FirstOrDefault<AuthenticationRequest>();

        } // GetByGuid

        public bool IsExistByCheckData(string checkData)
        {

            return GetByCheckData(checkData) != null;

        }

        public void UpdateById(int id, AuthenticationRequest request)
        {

            using (var context = new Context())
            {

                AuthenticationRequest actual = context.Requestek.Find(id);
                context.SaveChanges();

            }

        } // UpdateById

        public AuthenticationRequest UpdateByGuid(string guid, string checkData)
        {

            using (var context = new Context())
            {

                AuthenticationRequest actual = context.Requestek.Where(entity => entity.Guid == guid).FirstOrDefault<AuthenticationRequest>();
                int id = actual.Id;
                actual.Id = id;
                actual.Guid = guid;
                actual.CheckData = checkData;
                context.SaveChanges();

                return actual;

            }


        }

        public void DeleteAuthenticationRequest(AuthenticationRequest authenticationRequest)
        {
            var context = new Context();

            context.Requestek.Remove(authenticationRequest);
            context.SaveChanges();
        }
    }
}
