using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Poker.Tests
{
    [TestFixture]

    public class PokerTests
    {
        private static readonly PokerHandsChecker checker = new PokerHandsChecker();

        private static readonly IHand InvalidHand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
            });

        private static readonly IHand ValidFlush = new Hand(new List<ICard>() {
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
            });

        private static readonly IHand ValidFourOfAKind = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
            });


        private static readonly IHand ValidOnePair = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Hearts),
            });

        private static readonly IHand ValidTwoPair = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
            });


        [TestCase(CardFace.King, CardSuit.Hearts, "King Hearts")]
        [TestCase(CardFace.Queen, CardSuit.Diamonds, "Queen Diamonds")]
        [TestCase(CardFace.Nine, CardSuit.Spades, "Nine Spades")]
        public void Card_ToString_IsItCorrect(CardFace face, CardSuit suit, string result)
        {
            Card testCard = new Card(face, suit);

            string cardToString = testCard.ToString();

            Assert.AreEqual(result, cardToString);
        }


        [Test]
        public void Hand_ToString_IsItCorrect()
        {
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
            });

            string result = hand.ToString();
            string expectedResult = "Ace Clubs, Ace Diamonds, King Hearts";

            Assert.AreEqual(result, expectedResult);
        }
        
        [Test]
        public void PokerHandsChecker_Check_IsValidHand()
        {
            Assert.IsTrue(checker.IsValidHand(ValidFlush));
            Assert.IsFalse(checker.IsValidHand(InvalidHand));
        }

        [Test]
        public void PokerHandsChecker_Check_IsFlush()
        {
            Assert.IsTrue(checker.IsFlush(ValidFlush));
            Assert.IsFalse(checker.IsFlush(ValidFourOfAKind));
        }

        [Test]
        public void PokerHandsChecker_Check_IsFourOfAKind()
        {
            Assert.IsTrue(checker.IsFourOfAKind(ValidFourOfAKind));
            Assert.IsFalse(checker.IsFourOfAKind(ValidFlush));
        }

        [Test]
        public void PokerHandsChecker_Check_IsOnePair()
        {
            Assert.IsTrue(checker.IsOnePair(ValidOnePair));
            Assert.IsFalse(checker.IsOnePair(ValidFourOfAKind));
        }


        [Test]
        public void PokerHandsChecker_Check_IsTwoPair()
        {
            Assert.IsTrue(checker.IsTwoPair(ValidTwoPair));
            Assert.IsFalse(checker.IsTwoPair(ValidOnePair));
        }
    }
}
