namespace pathways_api.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Data.Entities;
    using Interfaces;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using pathways_common;
    using pathways_common.Extensions;

    public class UserService : PathwaysDataQueryService<User>, IUserService
    {
        public UserService(DataContext context) : base(context, context.Users)
        {
        }

        public User Create(User user)
        {
            if (string.IsNullOrEmpty(user.Username)) throw new AppException("Invalid username passed to the service");

            User existingUser = this.Retrieve(user.Username);

            Func<User> func;
            if (existingUser == null)
            {
                EntityEntry<User> entityEntry = this.context.Users.Add(user);
                func = () => entityEntry.Entity;
            }
            else if (existingUser.DirectoryName != user.DirectoryName)
            {
                existingUser.DirectoryName = user.DirectoryName;
                func = () => existingUser;
            }
            else
            {
                throw new AppException($"A user with username {user.Username} already exists.");
            }

            this.context.SaveChanges();

            return func();
        }

        public void Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public User GetByIdWithIncludes(int id)
        {
            throw new System.NotImplementedException();
        }

        public User Retrieve(string name)
        {
            return this.collection.FirstOrDefault(u => u.Username == name);
        }

        public User RetrieveOrCreate(string adEmail, string adName)
        {
            User user = this.context.Users.FirstOrDefault(u => u.Username == adEmail && u.DirectoryName == adName);

            if (user != null || string.IsNullOrEmpty(adEmail)) return user;

            user = new User(adEmail, adName);
            return this.Create(user);
        }

        public void UpdateRange(IList<User> userList)
        {
            foreach (User user in userList)
            {
                User dbUser = this.collection.FirstOrDefault(u => u.Username == user.Username);
                if (dbUser == null)
                {
                    dbUser = user;
                    this.context.Add(dbUser);
                }
                else
                {
                    dbUser.DomoIdentifier = user.DomoIdentifier;
                    this.context.Update(dbUser);
                }
            }

            this.context.SaveChanges();
        }
    }
}