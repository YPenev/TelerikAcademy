using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            var hashSetHand = new HashSet<ICard>(hand.Cards);

            if (hashSetHand.Count == 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            int count = 0;

            foreach (var cardOne in hand.Cards)
            {
                foreach (var cardTwo in hand.Cards)
                {
                    if (cardOne.Face == cardTwo.Face)
                    {
                        count++;
                        if (count == 4)
                        {
                            return true;
                        }
                    }
                }

                count = 0;
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (!hand.Cards[0].Suit.Equals(hand.Cards[i].Suit))
                {
                    return false;
                }
            }


            var orderedHand = hand.Cards.OrderBy(x => x.Face).ToList();

            for (int i = 1; i < orderedHand.Count; i++)
            {
                if (orderedHand[i - 1].Face + 1 != orderedHand[i].Face)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            return PairChecker(hand, 3, 1);
        }

        public bool IsTwoPair(IHand hand)
        {
            return PairChecker(hand, 2, 2);
        }

        public bool IsOnePair(IHand hand)
        {
            return PairChecker(hand, 2, 1);
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private bool PairChecker(IHand hand, int pairSize, int PairsCount)
        {
            int pairCount = 1;
            int numberOfPairs = 0;

            foreach (var firstCard in hand.Cards)
            {
                foreach (var secondCard in hand.Cards)
                {
                    if (firstCard.Face == secondCard.Face && firstCard.GetHashCode() != secondCard.GetHashCode())
                    {
                        pairCount++;
                    }
                }
                if (pairCount == pairSize)
                {
                    numberOfPairs++;
                }

                pairCount = 1;
            }

            if (numberOfPairs == PairsCount * 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}