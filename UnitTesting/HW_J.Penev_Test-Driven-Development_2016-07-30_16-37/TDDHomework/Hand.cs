using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            return string.Join(", ",this.Cards);
        }

        public int Count()
        {
            return this.Cards.Count;
        }

        public IList<ICard> OrderedCard()
        {
            throw new NotImplementedException();
        }
    }
}