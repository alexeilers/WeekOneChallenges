namespace BadgeChallenge 
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public List<string> AccessList { get; set; }
    

        public Badges(){}
        public Badges(int badgeID, List<string> accessList)
        {
            BadgeID = badgeID;
            AccessList = accessList;
        }
    }
}
