using Pokemon.Models.Entities;
using Pokemon.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon.Applications.ViewModels
{
    /// <summary>
    /// This class return players and data of account person that is logon
    /// </summary>
    public class AccountViewModel
    {
        private long IdAccount { get; }

        public AccountViewModel(long idAccount)
        {
            this.IdAccount = idAccount;
        }

        public Account Account {
            get
            {
                try
                {
                    using (var repository = new AccountRepository())
                    {
                        return repository.FindById(IdAccount);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }        

        public IEnumerable<Player> Players {
            get
            {
                try
                {
                    using (var repository = new PlayerRepository())
                    {
                        return repository.ListByParameter(p => p.Account_Id == IdAccount && p.Deleted == false).ToList();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
