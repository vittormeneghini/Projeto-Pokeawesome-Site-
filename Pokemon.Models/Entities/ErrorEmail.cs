using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pokemon.Models.Entities
{
    public class ErrorEmail
    {
        [Key]
        public string Name { get; set; }

        public string Email { get; set; }

        public bool Send { get; set; }
    }
}
