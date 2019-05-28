namespace pathways_api.Services
{
    using System;
    using System.Linq;
    using Data;
    using Data.Entities;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using pathways_common;

    public class UserService : PathwaysDataQueryService<User>, IUserService
    {
        public UserService(DataContext context) : base(context, context.Users)
        {
        }

        protected override Func<User, object> UpdateKey
        {
            get { return u => u.Username; }
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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByIdWithIncludes(int id)
        {
            throw new NotImplementedException();
        }

        public User Retrieve(string name)
        {
            return this.context.Users
                .Include(u => u.UserSkills)
                .FirstOrDefault(u => u.Username == name);
        }

        public User RetrieveOrCreate(string adEmail, string adName)
        {
            User user = this.context.Users.FirstOrDefault(u => u.Username == adEmail && u.DirectoryName == adName);

            if (user != null || string.IsNullOrEmpty(adEmail)) return user;

            user = new User(adEmail, adName);
            return this.Create(user);
        }

        protected override void MapUpdateFields(User targetObject, User sourceObject)
        {
            targetObject.DomoIdentifier = sourceObject.DomoIdentifier;
        }
    }
}