﻿namespace OnePiece.Models
{
    public class Pirate
    {
        public int PirateID { get; set; }
        public string Denomination { get; set; }

        public string Password { get; set; }
        public int TeamID { get; set; }
        public string Status { get; set; }

        public Team Team { get; set; }
    }

}
