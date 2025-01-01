namespace OnePiece.Models
{
    public class Proposal
    {
        public int ProposalID { get; set; }
        public int ProposedTreasureID { get; set; }
        public int ProposingPirateID { get; set; }
        public int RequestingPirateID { get; set; }
        public decimal? ProposedOfferAmount { get; set; }
        public decimal? CounterOfferAmount { get; set; }
        public int? Category { get; set; }
        public int State { get; set; }
        public DateTime DateProposal { get; set; }
        public DateTime? DateReplyProposal { get; set; }

        public Treasure ProposedTreasure { get; set; }
        public Pirate ProposingPirate { get; set; }
        public Pirate RequestingPirate { get; set; }
    }

}
