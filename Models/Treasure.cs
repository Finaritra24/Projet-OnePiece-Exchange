namespace OnePiece.Models
{
    public class Treasure
    {
        public int TreasureID { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int PirateID { get; set; }

        public Pirate Pirate { get; set; }
    }

}
