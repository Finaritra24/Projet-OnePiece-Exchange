using System.ComponentModel.DataAnnotations.Schema;

namespace OnePiece.Models
{
    [Table("treasure")]
    public class Treasure
    {
        public int TreasureID { get; set; }
        public int CategoryID { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int PirateID { get; set; }
        public int State { get; set; }

        public Pirate Pirate { get; set; }
        public Category Category { get; set; }
    }

}
