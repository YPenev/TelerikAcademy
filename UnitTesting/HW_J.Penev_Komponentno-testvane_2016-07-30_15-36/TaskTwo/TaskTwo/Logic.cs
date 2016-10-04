namespace Santase.Logic
{
    public enum PlayerPosition
    {
        NoOne = 0,
        FirstPlayer = 1,
        SecondPlayer = 2,
    }
}

namespace Santase.Logic.Cards
{
    public enum CardType
    {
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 1,
    }
}

namespace Santase.Logic.Cards
{
    public enum CardSuit
    {
        Club = 0, // ♣
        Diamond = 1, // ♦
        Heart = 2, // ♥
        Spade = 3 // ♠
    }
}

namespace Santase.Logic.Cards
{
    /// <summary>
    /// Immutable object to represent game card with suit and type.
    /// </summary>
    public class Card 
    {
        public Card(CardSuit suit, CardType type)
        {
            this.Suit = suit;
            this.Type = type;
        }

        public CardSuit Suit { get; }

        public CardType Type { get; }

        public static Card FromHashCode(int hashCode)
        {
            var suitId = (hashCode - 1) / 13;
            return new Card((CardSuit)suitId, (CardType)(hashCode - (suitId * 13)));
        }

        public int GetValue()
        {
            switch (this.Type)
            {
                case CardType.Nine:
                    return 0;
                case CardType.Jack:
                    return 2;
                case CardType.Queen:
                    return 3;
                case CardType.King:
                    return 4;
                case CardType.Ten:
                    return 10;
                case CardType.Ace:
                    return 11;
                default:
                    throw new InternalGameException("Invalid card type in GetValue()");
            }
        }

        public override bool Equals(object obj)
        {
            var anotherCard = obj as Card;
            return anotherCard != null && this.Equals(anotherCard);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int)this.Suit * 13) + (int)this.Type;
            }
        }

        public Card DeepClone()
        {
            return new Card(this.Suit, this.Type);
        }

        public override string ToString()
        {
            return $"{this.Type.ToString()}{this.Suit.ToString()}";
        }

        private bool Equals(Card other)
        {
            return this.Suit == other.Suit && this.Type == other.Type;
        }
    }
}