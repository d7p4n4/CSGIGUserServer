using Ac4yUtilityContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGIGUserServer
{
    public class EFUserTokenMethodsCAP
    {
        public UserToken Insert(UserToken user)
        {
            using (var ctx = new Context())
            {
                ctx.Database.EnsureCreated();

                ctx.Tokenek.Add(user);
                ctx.SaveChanges();
            }

            return user;

        }

        public UserToken GetById(int id)
        {
            return new Context().Tokenek.Find(id);
        }

        public bool IsExistById(int id)
        {
            return GetById(id) != null;
        }

        public UserToken GetByUserGuid(string guid)
        {
            return new Context().Tokenek
                    .Where(entity => entity.UserGuid == guid)
                    .FirstOrDefault<UserToken>();
        } // GetByGuid

        public bool IsExistByGuid(string guid)
        {

            return GetByUserGuid(guid) != null;

        }

        public List<UserToken> GetListByGuid(string guid)
        {
            return new Context().Tokenek
                .Where(t => t.UserGuid == guid)
                .ToList();
        }

        public UserToken GetByFBToken(string fbToken)
        {

            return new Context().Tokenek
                      .Where(entity => entity.fbToken == fbToken)
                      .FirstOrDefault<UserToken>();

        } // GetByGuid

        public bool IsExistByFBToken(string fbToken)
        {

            return GetByFBToken(fbToken) != null;

        }

        public void UpdateById(int id, UserToken user)
        {

            using (var context = new Context())
            {

                UserToken actual = context.Tokenek.Find(id);
                actual.UserGuid = user.UserGuid;
                context.SaveChanges();

            }

        } // UpdateById

        public void UpdateByUserGuid(string guid, UserToken user)
        {

            using (var context = new Context())
            {

                UserToken actual = context.Tokenek.Where(entity => entity.UserGuid == guid).FirstOrDefault<UserToken>();
                int id = actual.id;
                actual.id = id;
                context.SaveChanges();

            }
        }

            public void UpdateByFbToken(UserToken user)
            {

                using (var context = new Context())
                {

                    UserToken actual = context.Tokenek.Where(entity => entity.fbToken == user.fbToken).FirstOrDefault<UserToken>();

                    new Ac4yUtility().Object2Object(user, actual);
                actual.fbToken = user.fbToken;
                    context.SaveChanges();

                }
            }
    }
}
