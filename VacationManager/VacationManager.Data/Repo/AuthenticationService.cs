using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationManager.Data.Data;
using static VacationManager.Data.UserRepo;

namespace VacationManager.Data.Repo
{
    class AuthenticationService
    {
        public ApplicationUser LoggedUser { get; private set; }
        public void AuthenticateUser(string username, string password)
        {
            UserRepository userRepo = new UserRepository(new VacationDbContext());
            this.LoggedUser = userRepo.GetOne(u => u.UserN == username && u.PassW == password);
        }
    }
}
