using Pokemon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon.Repository.Repositories
{
    public class AccountRepository : Repository<Account>
    {
        public Account FindAccount(string name, string password)
        {
            try
            {
                return FindByParameter(p => p.Name.Equals(name) && p.Password.Equals(password));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
