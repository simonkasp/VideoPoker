using System.Linq;

namespace VideoPoker
{
    public class Rule
    {
        public bool IsDiscardCardsCorrect(int[] array)
        {
            int[] validValues = { 1, 2, 3, 4, 5 };

            return array.Any(validValues.Contains);
        }
    }
}
