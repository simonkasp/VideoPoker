namespace VideoPoker
{
    public class ScoreCalculator
    {
        private int _score;

        public ScoreCalculator()
        {
            _score = 0;
        }

        public int GetScore { get { return _score; } set { } }

        public void Calculate(Card[] hand)
        {

            if (HandCombinations.IsTwoPair(hand) == true)
                _score = 2;
            else if (HandCombinations.IsThreeOfAKind(hand) == true)
                _score = 3;
            else if (HandCombinations.IsStraight(hand) == true)
                _score = 4;
            else if (HandCombinations.IsFlush(hand) == true)
                _score = 6;
            else if (HandCombinations.IsFullHouse(hand) == true)
                _score = 9;
            else if (HandCombinations.IsFourOfAKind(hand) == true)
                _score = 25;
            else if (HandCombinations.IsStraightFlush(hand) == true)
                _score = 50;
            else if (HandCombinations.IsRoyalFlush(hand) == true)
                _score = 800;
            else if (HandCombinations.IsJackOrBetter(hand) == true)
                _score = 1;
            else
                _score = 0;
        }
    }
}
