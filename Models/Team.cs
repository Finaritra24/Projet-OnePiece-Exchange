﻿using System.ComponentModel.DataAnnotations.Schema;

namespace OnePiece.Models
{
    [Table("team")]
    public class Team
    {
        public int TeamID { get; set; }
        public string Denomination { get; set; }
    }

}
