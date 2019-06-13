using VideoPoker.Enums;

namespace VideoPoker
{
	public class CombinationDeterminator
	{
		public string GetCombinationName(int score)
		{
			switch (score)
			{
				case (int)Hand.JacksOrBetter:
					return "Jacks or Better";
				case (int)Hand.TwoPairs:
					return "Two Pairs";
				case (int)Hand.ThreeOfAKind:
					return "Three of a kind";
				case (int)Hand.Straight:
					return "Straight";
				case (int)Hand.Flush:
					return "Flush";
				case (int)Hand.FullHouse:
					return "Full House";
				case (int)Hand.FourOfAKind:
					return "Four of a kind";
				case (int)Hand.StraightFlush:
					return "Straight Flush";
				case (int)Hand.RoyalFlush:
					return "Royal Flush";
				default:
					return "Nothing";
			}
		}
	}
}

