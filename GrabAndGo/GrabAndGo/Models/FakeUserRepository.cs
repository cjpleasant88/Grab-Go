using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrabAndGo.Models
{
    public class FakeUserRepository : IUserRepository
    {
        public IQueryable<User> Users => new List<User>
        {
            new User {UserID = 1, FirstName = "Test User", LastName = "Test Last", Email = "test123@456.com", Password = "superSecret", ListID = 123, ListName = "Test List", StorePref = 1},
            new User {UserID = 2, FirstName = "John", LastName = "Smith", Email = "john@grabandgo.com", Password = "johnnyrocks", ListID = 3, ListName = "John's List", StorePref = 2}
        }.AsQueryable<User>();
    }
}
