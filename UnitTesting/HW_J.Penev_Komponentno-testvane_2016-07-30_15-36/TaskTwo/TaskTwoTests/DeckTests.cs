namespace Santase.Logic.Cards.Tests
{
    using System;
    using NUnit.Framework;
    using Santase.Logic.Cards;

    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void Deck_DeckCreationTest_IsCard24()
        {
           var testDeck = new  Deck();
            Assert.IsNotNull(testDeck);
            Assert.AreEqual(24, testDeck.CardsLeft);
        }
              
        [Test]
        public void Deck_GetNextCard_IsItDiffrent()
        {
            var testDeck = new Deck();
            var firstCard = testDeck.GetNextCard();
            var secondCard = testDeck.GetNextCard();

            Assert.AreNotSame(firstCard,secondCard);
        }

       
        [TestCase(CardSuit.Heart, CardType.Queen)]
        [TestCase(CardSuit.Club, CardType.King)]
        [TestCase(CardSuit.Spade, CardType.Ten)]
        public void Deck_ChangeTrump_AreTheTrumpChanged(CardSuit suit, CardType type )
        {
            var testDeck = new Deck();
            var newTrump = new Card(suit,type);
           
            testDeck.ChangeTrumpCard(newTrump);

            Assert.AreSame(newTrump,testDeck.TrumpCard);
        }

        [Test]
        public void Deck_GetLastCard_IsItThrowExeption()
        {
            var testDeck = new Deck();

            for (int i = 0; i < 24; i++)
            {
                testDeck.GetNextCard();
            }

          Assert.Throws<InternalGameException>(() => testDeck.GetNextCard());
        }
    }
}