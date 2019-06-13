using System;
using System.Collections.Generic;
using VideoPoker.Enums;

namespace VideoPoker
{
    public class Deck : Card
    {
        private List<Card> _deck;

        public Deck()
        {
            _deck = new List<Card>(52);
        }

        public List<Card> GetDeck { get { return _deck; } }

        public void CreateDeck()
        {
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    _deck.Add(new Card { Suit = suit, Value = value });
                }
            }
            ShuffleDeck();
        }

        private void ShuffleDeck()
        {
            var rand = new Random();
            Card temp;

            for (int j = 0; j < 1000; j++)
            {
                for (int i = 0; i < 52; i++)
                {
                    int nextPosition = rand.Next(13);
                    temp = _deck[i];
                    _deck[i] = _deck[nextPosition];
                    _deck[nextPosition] = temp;
                }
            }
        }
    }
}
