using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pokemon.Models.Entities
{
    [Table("accounts")]
    public class Account
    {
        [Key]
        public long Id { get; set; }
        
        public string Name { get; set; }

        public string Password { get; set; }

        public long PremDays { get; set; }

        public long LastDay { get; set; }

        public string Email { get; set; }

        public string Key { get; set; }

        public bool Blocked { get; set; }

        public long Warnings { get; set; }

        public long Group_Id { get; set; }

        public long VipTime { get; set; }

        public long? Page_Access { get; set; }

        public long? Page_LastDay { get; set; }

        public string Email_New { get; set; }

        public long? Email_New_Time { get; set; }

        public string RlName { get; set; }

        public string Location { get; set; }

        public long? Created { get; set; }

        public string Email_Code { get; set; }

        public long? Next_Email { get; set; }

        public long? Premium_Points { get; set; }

        public string NickName { get; set; }

        public string Avatar {get;set;}

        public string About_Me { get; set; }

        public virtual List<Player> Player { get; set; }

        /// <summary>
        /// This method add account
        /// </summary>
        public void AddAccount(string password, string email, string nickname)
        {
            this.Name = "creating";
            this.Password = password;
            this.Email = email;
            this.NickName = nickname;
            this.PremDays = 0;
            this.LastDay = 0;
            this.Key = "";
            this.Blocked = false;
            this.Group_Id = 1;
            this.VipTime = 0;
        }
    }
}
