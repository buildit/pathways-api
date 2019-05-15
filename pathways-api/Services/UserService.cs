namespace pathways_api.Services
{
    using System.Collections.Generic;
    using Data;
    using Data.Entities;
    using Interfaces;

    public class UserService : PathwaysDataQueryService<User>, IUserService
    {
        public UserService(DataContext context, IEnumerable<User> collection) : base(context, collection)
        {
        }

        public User Create(User user)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public User RetrieveOrCreate(string adEmail, string adName)
        {
            throw new System.NotImplementedException();
        }
    }
}