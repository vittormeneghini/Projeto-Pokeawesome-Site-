using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.Applications.ViewModels
{
    public class LoginViewModel
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string RlName { get; set; }

        public string Email { get; set; }        

        //Return true if password is equal confirmed
        public bool PasswordIsConfirmed()
        {
            if (this.Password != this.ConfirmPassword)
                return false;

            return true;
        }
    }
}
