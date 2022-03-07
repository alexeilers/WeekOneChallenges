using KomodoCafeRepo;
public class ProgramUI {
private readonly MenuOptionsRepository _menuRepo = new MenuOptionsRepository();

public void Run(){
    RunMenu();
    //SeedContentList();

}

public void RunMenu()
{
    bool continueToRun = true;
    while(continueToRun)
    {
        Console.Clear();

        Console.WriteLine("Enter the number of the option you'd like to select:\n" + 
        "1) Show all Menu Options\n" + 
        "2) Add new Menu Items\n" +
        "3) Remove Menu Items\n" +
        "4) Exit");
        

        string userInput = Console.ReadLine();

        switch(userInput)
        {
            case "1":
            ShowAllOptions();
            break;
            case "2":
            AddMenuItems();
            break;
            case "3":
            RemoveMenuItems();
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

private void ShowAllOptions(){
    Console.Clear();
    List<MenuOptions> listOfContent = _menuRepo.GetContents();

    foreach(MenuOptions content in listOfContent) {
        DisplayContent(content);
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

    private void AddMenuItems(){
    Console.Clear();
    
    MenuOptions content = new MenuOptions();
    Console.Write("Please enter new Menu Option name: ");
    content.MealName = Console.ReadLine();

    Console.Write("What meal number will this be?: ");
    content.MealNumber = Console.ReadLine();

    Console.Write("Please enter at brief description: ");
    content.MealDescription = Console.ReadLine();

    Console.Write("Please enter a price: $");
    content.MealPrice = double.Parse(Console.ReadLine());

    Console.Write("Please enter each ingredient followed by a comma: ");
    content.IngredientsList = Console.ReadLine();

    _menuRepo.AddContentToDirectory(content);

    }


    private void RemoveMenuItems(){
    Console.Clear();
    Console.WriteLine("Which Menu Item would you like to remove?");
    List<MenuOptions> contentList = _menuRepo.GetContents();
    int count = 0;

    foreach(MenuOptions content in contentList){
        count++;
        Console.WriteLine($"{count}. {content.MealName}");
    }

    int targetContentID = int.Parse(Console.ReadLine());
    int targetIndex = targetContentID -1;

    if(targetIndex >= 0 && targetIndex < contentList.Count){
        MenuOptions desiredContent = contentList[targetIndex];

        if(_menuRepo.DeleteExistingContent(desiredContent)){
            Console.WriteLine($"{desiredContent.MealName} was successfully removed.");
        }
        else Console.WriteLine("Invalid input. Please try again");
    }

    else Console.WriteLine("No content has that ID.");

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();

}

private void DisplayContent(MenuOptions content){
    Console.WriteLine($"Meal Number: {content.MealNumber}\n" +
    $"Meal Name: {content.MealName}\n" +
    $"Description: {content.MealDescription}\n" +
    $"Ingredients: {content.IngredientsList}\n");

}

}