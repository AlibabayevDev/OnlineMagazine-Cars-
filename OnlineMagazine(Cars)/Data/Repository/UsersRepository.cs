using InternetMagazin.Data;
using InternetMagazin.Data.Models.Entities;
using OnlineMagazine_Cars_.Data.Interfaces;
using System.Collections.Generic;

namespace OnlineMagazine_Cars_.Data.Repository
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
