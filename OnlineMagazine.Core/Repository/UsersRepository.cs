using OnlineMagazine.Data;
using OnlineMagazine.Data.Models.Entities;
using OnlineMagazine.Data.Interfaces;
using System.Collections.Generic;

namespace OnlineMagazine.Data.Repository
{
    public class UsersRepository : IAllUsers
    {
        private readonly AppDbContent appDbContent;
        public UsersRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public IEnumerable<User> Users => appDbContent.Users;

    }
}
