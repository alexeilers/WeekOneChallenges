namespace KomodoClaimsRepo;


public class ClaimInfoRepository 
{
    protected readonly List<ClaimInfo> _contentDirectory = new List<ClaimInfo>();

    


    public List<ClaimInfo> GetContents()
    {
        return _contentDirectory;
    }

    private Queue<ClaimInfo> _claimQueue = new Queue<ClaimInfo>();

    public Queue<ClaimInfo> GetClaims()
    {
        return _claimQueue;
    }



    public int claimCount = 0;

    public bool AddContentToDirectory(ClaimInfo content)
    {
        claimCount++;

        if ((content.DateOfClaim - content.DateOfIncident).TotalDays < 30){
            content.IsValid = true;}
            else content.IsValid = false;

        int startingCount = _contentDirectory.Count;

        _contentDirectory.Add(content);

        bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
        return wasAdded;
    }

    public bool AddContentToQueue(ClaimInfo content)
    {
        claimCount++;

        if ((content.DateOfClaim - content.DateOfIncident).TotalDays < 30){
            content.IsValid = true;}
            else content.IsValid = false;

        int startingCount = _contentDirectory.Count;

        _claimQueue.Enqueue(content);

        bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
        return wasAdded;
    }




}