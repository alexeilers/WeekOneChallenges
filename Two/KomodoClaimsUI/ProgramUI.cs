using KomodoClaimsRepo;
public class ProgramUI {
private readonly ClaimInfoRepository _claimsRepo = new ClaimInfoRepository();

private ClaimInfoRepository _claimQueue = new ClaimInfoRepository();


public void Run()
{
    SeedContentList();
    RunMenu();
    
}

public void RunMenu()
{
    bool continueToRun = true;
    while(continueToRun)
    {
        Console.Clear();

        Console.WriteLine("Enter the number of the option you'd like to select:\n\n" + 
        "1) See all claims\n" + 
        "2) Take care of next claim\n" +
        "3) Enter a new claim\n" +
        "4) Exit");
    

    string userInput = Console.ReadLine();

        switch(userInput)
        {
            case "1":
            SeeAllClaims();
            break;
            case "2":
            NextClaim();
            break;
            case "3":
            NewClaim();
            break;
            case "4":
            continueToRun = false;
            break;
            default:
            Console.WriteLine("Please enter a valid number between 1 and 4.\n" +
            "Press any key to continue...");
            Console.ReadKey();
            break;

        }
    }
}

private void SeeAllClaims(){
    Console.Clear();
    List<ClaimInfo> listOfContent = _claimsRepo.GetContents();

    foreach(ClaimInfo content in listOfContent) {
        DisplayContent(content);
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

private void DisplayContent(ClaimInfo content)
{
    Console.WriteLine($"ClaimID: {content.ClaimID}\n" +
    $"Claim Type: {content.ClaimType}\n" +
    $"Description: {content.ClaimDescription}\n" +
    $"Claim Amount: ${content.ClaimAmount}\n" +
    $"Date of Incident: {content.DateOfIncident}\n" +
    $"Date of Claim: {content.DateOfClaim}\n"+
    $"Claim can still be filed? {content.IsValid}\n");

}


private void NextClaim()
{
    Console.Clear();
    
    Queue<ClaimInfo> claimQueue = _claimQueue.GetClaims();

    do
    {
        Console.Clear();
        ClaimInfo firstItem = claimQueue.Peek();
        Console.WriteLine($"Claim ID: {firstItem.ClaimID}");
        Console.Write("Would you like to work this claim now? y/n: ");
        string response = Console.ReadLine();
        switch (response)
        {
            case "y":
            claimQueue.Dequeue();
            Console.WriteLine("Total remaining claims: {0}", claimQueue.Count);
            Console.WriteLine("Press enter to move to next queue item.");
            Console.ReadLine();
            break;

            case "n":
            RunMenu();
            break;
        }
    }
    while (claimQueue.Count > 0);
    Console.WriteLine("You have no remaining claims.\n\nPress any key to return to main menu...");


    
}


private void NewClaim(){
    Console.Clear();
    
    ClaimInfo content = new ClaimInfo();
    Console.Write("Enter a Claim ID: ");
    content.ClaimID = int.Parse(Console.ReadLine());
    Console.Clear();

    Console.WriteLine("Enter the claim type:\n" +
    "1) Car\n" +
    "2) Home\n" +
    "3) Theft\n");
    string typeChoice = Console.ReadLine();
        switch(typeChoice)
        {  
            case "1":
            content.ClaimType = "Car";
            Console.Clear();
            break;
            case "2":
            content.ClaimType = "Home";
            Console.Clear();
            break;
            case "3":
            content.ClaimType = "Theft";
            Console.Clear();
            break;
        }

    Console.Write("Enter description: ");
    content.ClaimDescription = Console.ReadLine();
    Console.Clear();

    Console.Write("Enter claim amount: $");
    content.ClaimAmount = double.Parse(Console.ReadLine());
    Console.Clear();

    Console.WriteLine("DATE OF INCIDENT:\n ");
    Console.Write("Month (MM): ");
    string incidentMonth = Console.ReadLine();
    int month = Int32.Parse(incidentMonth);
    Console.Write("Day (DD): ");
    string incidentDay = Console.ReadLine();
    int day = Int32.Parse(incidentDay);
    Console.Write("Year (YYYY): ");
    string incidentYear = Console.ReadLine();
    int year = Int32.Parse(incidentYear);
    DateTime dateOfIncident = new DateTime(year, month, day);
    content.DateOfIncident = dateOfIncident;
    Console.Clear();

    Console.WriteLine("DATE OF CLAIM SUBMISSION:\n ");
    Console.Write("Month (MM): ");
    string claimMonth = Console.ReadLine();
    int monthTwo = Int32.Parse(claimMonth);
    Console.Write("Day (DD): ");
    string claimDay = Console.ReadLine();
    int dayTwo = Int32.Parse(claimDay);
    Console.Write("Year (YYYY): ");
    string claimYear = Console.ReadLine();
    int yearTwo = Int32.Parse(claimYear);
    DateTime dateOfClaim = new DateTime(yearTwo, monthTwo, dayTwo);
    content.DateOfClaim = dateOfClaim;

  

    _claimsRepo.AddContentToDirectory(content);
    _claimQueue.AddContentToQueue(content);

}

private void SeedContentList()
    {
    ClaimInfo claimOne =  new ClaimInfo (1, "Car", "Car accident on 465.", 400.00, new DateTime(2018, 04, 25), new DateTime (2018, 04, 27), true);
    ClaimInfo claimTwo =  new ClaimInfo (2, "Home", "House fire in kitchen.", 4000.00, new DateTime (2018, 04, 11), new DateTime (2018, 04, 12), true);
    ClaimInfo claimThree =  new ClaimInfo (3, "Theft", "Stolen pancakes.", 4.00, new DateTime (2018, 04 , 27), new DateTime (2018, 06, 01), true);

    _claimsRepo.AddContentToDirectory(claimOne);
    _claimsRepo.AddContentToDirectory(claimOne);
    _claimsRepo.AddContentToDirectory(claimOne);

    _claimQueue.AddContentToQueue(claimOne);
    _claimQueue.AddContentToQueue(claimTwo);
    _claimQueue.AddContentToQueue(claimThree);

    }

    

}