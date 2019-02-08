using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pokemon.Models.Entities
{
    [Table("player_items")]
    public class PlayerItems
    {
        public PlayerItems()
        {

        }

        public PlayerItems(long idplayer, long pid, long sid, long itemType, long count, byte[] atributes)
        {
            this.Player_Id = idplayer;
            this.Pid = pid;
            this.Sid = sid;
            this.ItemType = itemType;
            this.Count = count;
            this.Attributes = atributes;
        }   
  
        public long Player_Id { get; set; }

        public long Pid { get; set; }
       
        public long Sid { get; set; }

        public long ItemType { get; set; }

        public long Count { get; set; }

        public byte[] Attributes { get; set; }
    }
}
