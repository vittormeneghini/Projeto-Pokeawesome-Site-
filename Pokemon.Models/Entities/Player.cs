using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pokemon.Models.Entities
{
    [Table("players")]
    public class Player
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public long World_Id { get; set; }

        public long Group_Id { get; set; }

        public long Account_Id { get; set; }

        public long Level { get; set; }

        public long Vocation { get; set; }

        public long Health { get; set; }

        public long HealthMax { get; set; }

        public long Experience { get; set; }

        public long LookBody { get; set; }

        public long LookFeet { get; set; }

        public long LookHead { get; set; }

        public long LookLegs { get; set; }

        public long LookType { get; set; }

        public long LookAddons { get; set; }

        public long MagLevel { get; set; }

        public long Mana { get; set; }

        public long ManaMax { get; set; }

        public long ManaSpent { get; set; }

        public long Soul { get; set; }

        public long Town_Id { get; set; }

        public long Posx { get; set; }

        public long Posy { get; set; }

        public long Posz { get; set; }

        public byte[] Conditions { get; set; }

        public long Cap { get; set; }

        public long Sex { get; set;}

        public long LastLogin { get; set;}

        public long LastIp { get; set; }

        public bool Save { get; set; }

        public bool Skull { get; set; }

        public long SkullTime { get; set; }

        public long Rank_Id { get; set; }

        public string GuildNick { get; set; }

        public long LastLogout { get; set; }

        public long Blessings { get; set; }
        public long Balance { get; set; }
        public long Stamina { get; set; }
        public long Direction { get; set; }
        public long Loss_Experience { get; set; }
        public long Loss_Mana { get; set; }
        public long Loss_Skills { get; set; }
        public long Loss_Containers { get; set; }
        public long Loss_Items { get; set; }
        public long Premend { get; set; }
        public bool Online { get; set; }
        public long Marriage { get; set; }
        public long Promotion { get; set; }
        public bool Deleted { get; set; }
        public string Description { get; set; }
        public string Old_Name { get; set; }
        //public int Hide_Char { get; set; }
        //public long WorldTransfer { get; set; }
        public long Created { get; set; }
        //public long Nick_Verify { get; set; }
        public string Comment { get; set; }


        [ForeignKey("Account_Id")]
        public virtual Account Account { get; set; }


        [NotMapped]
        public string Gender { get; set; }

        public void AddPlayer(string name, long account_id, long sex)
        {
            this.Name = name;
            this.Account_Id = account_id;
            this.Sex = sex;
            this.Level = 10;
            this.World_Id = 0;
            this.Vocation = 1;
            this.Health = 150;
            this.HealthMax = 150;
            this.Experience = 9300;
            this.LookType = sex == 1 ? 510 : 511;
            this.LookAddons = 0;
            this.MagLevel = 0;
            this.Mana = 0;
            this.ManaMax = 6;
            this.ManaSpent = 0;
            this.Soul = 0;
            this.Town_Id = 1;
            this.Posx = 50;
            this.Posy = 50;
            this.Posz = 50;
            this.Conditions = new byte[0];
            this.Cap = 7;
            this.Skull = false;
            this.SkullTime = 0;
            this.Rank_Id = 0;
            this.GuildNick = "";
            this.Blessings = 0;
            this.Balance = 0;
            this.Stamina = 201600000;
            this.Direction = 0;
            this.Loss_Experience = 0;
            this.Loss_Mana = 100;
            this.Loss_Skills = 100;
            this.Loss_Containers = 100;
            this.Loss_Items = 100;
            this.Premend = 0;
            this.Online = false;
            this.Marriage = 0;
            this.Promotion = 0;
            this.Deleted = false;
            this.Description = "";
            this.Save = true;           
        }


    }
}
