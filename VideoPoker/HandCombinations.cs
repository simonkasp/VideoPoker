using System.Linq;
using VideoPoker.Enums;

namespace VideoPoker
{
    public static class HandCombinations
    {
        private static Card[] Sort(Card[] hand)
        {          
            var sortedHand = new Card[5];

            var sortedQuery = from h in hand
                              orderby h.Value
                              select h;

            int i = 0;

            foreach (var card in sortedQuery.ToList())
            {
                sortedHand[i] = card;
                i++;
            }

            return sortedHand;
        }

        public static bool IsPair(Card[] hand)
        {
            var checkQuery = hand.GroupBy(c => c.Value)
                                  .Count(g => g.Count() == 2) == 1;

            return checkQuery;
        }



        public static bool IsTwoPair(Card[] hand)
        {
            var checkQuery = hand.GroupBy(c => c.Value)
                             .Count(g => g.Count() >= 2) == 2;

            return checkQuery;

        }

        public static bool IsThreeOfAKind(Card[] hand)
        {
            var checkQuery = hand.GroupBy(c => c.Value)
                                  .Any(g => g.Count() == 3);

            return checkQuery;
        }

        public static bool IsStraight(Card[] hand)
        {
            var sortedHand = Sort(hand);

            if (sortedHand[0].Value + 1 == sortedHand[1].Value &&
                sortedHand[1].Value + 1 == sortedHand[2].Value &&
                sortedHand[2].Value + 1 == sortedHand[3].Value &&
                sortedHand[3].Value + 1 == sortedHand[4].Value)
            {
                return true;
            }
            else if(sortedHand[1].Value == CardValue.Ten &&
                    sortedHand[2].Value == CardValue.Jack &&
                    sortedHand[3].Value == CardValue.Queen &&
                    sortedHand[4].Value == CardValue.King &&
                    sortedHand[0].Value == CardValue.Ace)
            {
                return true;
            }
            return false;
        }

        public static bool IsFlush(Card[] hand)
        {
            var checkQuery = hand.GroupBy(c => c.Suit)
                                  .Count(g => g.Count() >= 5) == 1;

            return checkQuery;
        }

        public static bool IsFullHouse(Card[] hand)
        {
            return IsPair(hand) && IsThreeOfAKind(hand);
        }

        public static bool IsFourOfAKind(Card[] hand)
        {
            var checkQuery = hand.GroupBy(c => c.Value)
                                  .Any(g => g.Count() == 4);

            return checkQuery;
        }

        public static bool IsStraightFlush(Card[] hand)
        {
            return IsFlush(hand) && IsStraight(hand);
        }

        public static bool IsRoyalFlush(Card[] hand)
        {
            var checkQuery = hand.Min(c => (int)c.Value) == (int)CardValue.Ten &&
                                 IsStraightFlush(hand);

            return checkQuery;
        }

        public static bool IsJackOrBetter(Card[] hand)
        {
            if (hand[0].Value == hand[1].Value &&
                hand[0].Value == CardValue.Ace || hand[0].Value >= CardValue.Jack)
                return true;

            else if (hand[1].Value == hand[2].Value &&
                    hand[1].Value == CardValue.Ace || hand[1].Value >= CardValue.Jack)
                return true;

            else if (hand[2].Value == hand[3].Value &&
                    hand[2].Value == CardValue.Ace || hand[2].Value >= CardValue.Jack)
                return true;

            else if (hand[3].Value == hand[4].Value &&
                    hand[3].Value == CardValue.Ace || hand[3].Value >= CardValue.Jack)
                return true;

            return false;
        }
    }
}
