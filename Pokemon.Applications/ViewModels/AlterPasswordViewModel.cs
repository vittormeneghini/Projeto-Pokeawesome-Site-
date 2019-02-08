using Pokemon.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.Applications.ViewModels
{
    public class AlterPasswordViewModel
    {

        private string SenhaAntiga { get; set; }

        private string SenhaNova { get; set; }
        
        /// <summary>
        /// This id is of account
        /// </summary>        
        public bool AlterarSenha(long id)
        {
            using (var repository = new AccountRepository())
            {
                var acc = repository.FindById(id);

                if (acc.Password.Equals(SenhaAntiga))
                {
                    acc.Password = SenhaNova;
                    
                    repository.SaveAll();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
