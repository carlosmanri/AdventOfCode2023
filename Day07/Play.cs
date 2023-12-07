namespace Day07;

public class Play : IComparable<Play>
{

    private string _labels = "23456789TJQKA";

    public string Hand { get; set; }
    public int Bid { get; set; }

    public int CompareTo(Play? other)
    {
        var cards = Hand.GroupBy(c => c).Select(c => new { Card = c.Key, Count = c.Count() }).OrderByDescending(c => c.Count);
        var otherCards = other.Hand.GroupBy(c => c).Select(c => new { Card = c.Key, Count = c.Count() }).OrderByDescending(c => c.Count);

        if (cards.Count() < otherCards.Count()) return 1;
        else if (cards.Count() > otherCards.Count()) return -1;
        else if (cards.First().Count > otherCards.First().Count) return 1;
        else if (cards.First().Count < otherCards.First().Count) return -1;

        for (int i = 0; i < Hand.Length; i++)
        {
            if (_labels.IndexOf(Hand[i]) > _labels.IndexOf(other.Hand[i])) return 1;
            else if (_labels.IndexOf(Hand[i]) < _labels.IndexOf(other.Hand[i])) return -1;
        }

        return 0;
    }
}
