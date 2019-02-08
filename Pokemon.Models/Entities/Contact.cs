using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pokemon.Models.Entities
{
    public class Contact
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }     

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
