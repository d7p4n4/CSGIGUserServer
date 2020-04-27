using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGIGUserServer

{
    public class EFUserMethodsCAP
    {
        public User Insert(User user)
        {
            if (user.CreatedAt == DateTime.MinValue)
            {
                user.CreatedAt = DateTime.Now;
            }
            if (user.UpdatedAt == DateTime.MinValue)
            {
                user.UpdatedAt = DateTime.Now;
            }

            using (var ctx = new Context())
            {
                ctx.Database.EnsureCreated();

                ctx.Userek.Add(user);
                ctx.SaveChanges();
            }

            return user;

        }

        public User GetById(int id)
        {
            return new Context().Userek.Find(id);
        }

        public bool IsExistById(int id)
        {
            return GetById(id) != null;
        }

      public User GetByGuid(string guid)
        {
            return new Context().Userek
                    .Where(entity => entity.Guid == guid)
                    .FirstOrDefault<User>();
        } // GetByGuid

      public bool IsExistByGuid(string guid)
        {

          return GetByGuid(guid) != null;

      }
       
        public void UpdateById(int id, User user)
        {

            using (var context = new Context())
            {

                User actual = context.Userek.Find(id);
                context.SaveChanges();

            }

      } // UpdateById

      public void UpdateByGuid(string guid, User user)
        {

          using (var context = new Context())
            {

             User actual = context.Userek.Where(entity => entity.Guid == guid).FirstOrDefault<User>();
                int id = actual.Id;
                actual.Id = id;
                actual.Guid = guid;
                context.SaveChanges();

          }


    }

        public void DeleteUser(User user)
        {
            var context = new Context();

            context.Userek.Remove(user);
        }

    }
}
