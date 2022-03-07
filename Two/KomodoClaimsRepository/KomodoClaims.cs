namespace KomodoClaimsRepo;


public class ClaimInfo
{
    public int ClaimID { get; set; }
    public string ClaimType { get; set; }
    public string ClaimDescription { get; set; }
    public double ClaimAmount { get; set; }
    public DateTime DateOfIncident{ get; set; }
    public DateTime DateOfClaim { get; set; }
    public bool IsValid { get; set; }
    
    public ClaimInfo(){}
    public ClaimInfo(int claimID, string claimType, string claimDescription, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
    {
        ClaimID = claimID;
        ClaimType = claimType;
        ClaimDescription = claimDescription;
        ClaimAmount = claimAmount;
        DateOfIncident = dateOfIncident;
        DateOfClaim = dateOfClaim;
        IsValid = isValid;
    }

}