using System.ComponentModel.DataAnnotations.Schema;

namespace OnePiece.Models
{
    [Table("category")]
    public class Category
    {
        public int CategoryID { get; set; }
        public string Denomination { get; set; }
    }
}
