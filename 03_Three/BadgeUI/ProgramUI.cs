namespace BadgeChallenge 
{
    class Program
    {
        static void Main(string[] args)
        {
            BadgeRepository badgeRepo = new BadgeRepository();
            Dictionary<int, List<string>> badgeDictionary = badgeRepo.GetDictionary();

            string response = null;
            while(response != "4")
            {
                Console.Clear();
                Console.WriteLine($"Welcome to the Badge Access Portal. What would you like to do?\n" +
                    $"1. Add a badge\n" +
                    $"2. Edit a badge\n" +
                    $"3. List all badges\n" +
                    $"4. Exit");
                response = Console.ReadLine();

                if (response == "1")
                {
                    Console.Clear();
                    List<string> doorList = new List<string>();
                    string doorResponse = "y";

                    Console.Write("What is the number on the badge: ");
                    int badgeNum = Int32.Parse(Console.ReadLine());
                    while (doorResponse != "n")
                    {
                        if (doorResponse == "y")
                        {
                            Console.Write("List the door needed for badge access: ");
                            string newDoor = Console.ReadLine();
                            doorList.Add(newDoor);
                            Console.Write("Add another door? y/n: ");
                            doorResponse = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                            Console.Write("Add another door? y/n: ");
                            doorResponse = Console.ReadLine();
                        }
                    }

                    badgeDictionary.Add(badgeNum, doorList);
                }
                else if (response == "2")
                {
                    Console.Clear();
                    Console.Write("Enter a badge number to edit: ");
                    int editBadge = Int32.Parse(Console.ReadLine());

                    if (badgeDictionary.Keys.Contains(editBadge))
                    {
                        List<string> tempList = badgeDictionary[editBadge];

                        Console.Write($"{editBadge} has access to doors: ");
                        foreach (string door in tempList)
                        {
                            Console.Write($"{door} ");
                        }
                        Console.WriteLine($"\nWhat would you like to do?" +
                            $"\n\t1. Remove a door" +
                            $"\n\t2. Add a door");
                        string editDoors = Console.ReadLine();
                        Console.Clear();
                        switch (editDoors)
                        {
                            case "1":
                                Console.WriteLine("Which door access would you like to remove?");
                                int count = 0;
                                foreach (string door in tempList)
                                {
                                    count++;
                                    Console.WriteLine(count + ". " + door);
                                }

                                int removeDoor = Int32.Parse(Console.ReadLine());
                                if (removeDoor > 0)
                                    removeDoor--;

                                tempList.RemoveAt(removeDoor);
                                Console.Write($"Removed." +
                                    $"\n{editBadge} now has access to: ");
                                foreach (string door in tempList)
                                {
                                    Console.Write($"{door} ");
                                }
                                break;
                            case "2":
                                Console.Write("Enter the door you would like to add: ");
                                string addDoor = (Console.ReadLine());
                                tempList.Add(addDoor);
                                Console.WriteLine($"{addDoor} has been added to badge {editBadge}.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no badge with that ID.");
                    }
                    Console.ReadLine();
                }
                else if (response == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Key \t\tDoor Access");

                    for (int i = 0; i < badgeDictionary.Count; i++)
                    {
                        string doorListToString = "";
                        int count = 0;
                        string comma;
                        foreach (string door in badgeDictionary.Values.ElementAt(i))
                        {
                            count++;
                            if (count < badgeDictionary.Values.ElementAt(i).Count)
                                comma = ", ";
                            else
                                comma = "";
                            doorListToString = doorListToString + door + comma;
                        }
                        Console.WriteLine($"{badgeDictionary.Keys.ElementAt(i)}\t\t{doorListToString}");
                    }

                    Console.Read();
                }
                else if (response=="4")
                {
                    break;
                }
            }
        }
    }
}