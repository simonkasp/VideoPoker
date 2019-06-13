using System;
using System.Linq;

namespace VideoPoker
{
    public class PlayerHand : Deck
    {
        private Card[] _hand;
        private ScoreCalculator _calculator;
        private int _score;
        private int _totalScore;
        private int previousScore;
        private CombinationDeterminator _combinationDeterminator;
        private string _combinationText;

        public PlayerHand()
        {
            _hand = new Card[5];
            _calculator = new ScoreCalculator();
            _combinationDeterminator = new CombinationDeterminator();
        }

        public void StartGame()
        {
            CreateDeck();
            GetHand();
            CalculateScoreStart();
            ShowHand();
            previousScore = _score;
        }

        public void ContinueGame()
        {
            SelectCards();
            CalculateScoreContinue();
            ShowHand();
        }

        public void GetHand()
        {
            for (int i = 0; i < 5; i++)
            {
                _hand[i] = GetDeck[i];
            }
        }

        public void ShowHand()
        {
            var i = 1;

            foreach (var card in _hand)
            {
                Console.WriteLine("["+i+"]" +" " + card.Value + " of " + card.Suit);
                i++;
            }

            Console.WriteLine("Score: " + _totalScore);
            Console.WriteLine("Combination: " + _combinationText);
        }

        private void CalculateScoreStart()
        {
            _calculator.Calculate(_hand);
            _score = _calculator.GetScore;

            _combinationText = _combinationDeterminator.GetCombinationName(_score);

            _totalScore += _score;
        }

        private void CalculateScoreContinue()
        {
            _calculator.Calculate(_hand);
            _score = _calculator.GetScore;

            _combinationText =_combinationDeterminator.GetCombinationName(_score);

            _totalScore += _score;

            if (previousScore <= _score)
                _totalScore -= previousScore;

            else if (previousScore > _score)
                _totalScore -= previousScore;
        }

        public void SelectCards()
        {
            var rule = new Rule();
            int[] splitIndexesInt = { };

            Console.WriteLine("Enter the cards indexes you want to discard: (numbers must be separated by commas).");
            string indexesHolder = Console.ReadLine();

            string[] splitIndexes = indexesHolder.Split(',');

            try
            {
                splitIndexesInt = Array.ConvertAll(splitIndexes, int.Parse);

            }
            catch (System.FormatException)
            {
                Console.WriteLine("Numbers must be separated by commas only.");
            }

            if(rule.IsDiscardCardsCorrect(splitIndexesInt) == false)
            {
                Console.WriteLine("You can choose between 1 and 5 cards only.");
                SelectCards();
            }

            var updatedHand = _hand.Where((i, n) => !splitIndexesInt.Contains(n + 1)).ToArray();
            _hand = updatedHand.Concat(GetDeck.Skip(5).Take(5 - updatedHand.Length)).ToArray();
        }
    }
}
