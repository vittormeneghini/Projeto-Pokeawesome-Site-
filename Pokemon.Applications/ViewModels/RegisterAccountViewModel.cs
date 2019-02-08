using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.Applications.ViewModels
{
    public class RegisterAccountViewModel
    {
        public string Name { get; internal set; }
       
        public bool TermCondition { get;  set; }
 
        [Required(ErrorMessage = "Por favor informe uma senha.")]
        [MinLength(8, ErrorMessage = "A senha deve conter pelo menos 8 caractéres.")]
        public string Password { get;  set; }

        [Required(ErrorMessage = "Por favor informe a confirmação da senha.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Por favor informe um e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor informe um apelido.")]
        [MinLength(4, ErrorMessage = "O apelido deve conter pelo menos 4 caractéres.")]
        public string NickName { get; set; }
    }
}
