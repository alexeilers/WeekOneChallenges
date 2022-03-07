namespace BadgeChallenge 
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        public void CreateBadge(int badgeNum, List<string> list)
        {
            Badges newBadge = new Badges(badgeNum, list);

            _badgeDictionary.Add(newBadge.BadgeID, newBadge.AccessList);
        }

        public Dictionary<int,List<string>> GetDictionary()
        {
            return _badgeDictionary;
        }
    }

}