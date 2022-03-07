namespace KomodoCafeRepo;
public class MenuOptions
{
    public string MealNumber{ get; set; }
    public string MealName { get; set; }
    public string MealDescription { get; set; }
    public string IngredientsList { get; set; }
    public double MealPrice { get; set; }
   

    public MenuOptions(){}
    public MenuOptions(string mealNumber, string mealName, string mealDescription, string ingredientsList, double mealPrice){
        MealNumber = mealNumber;
        MealName = mealName;
        MealDescription = mealDescription;
        IngredientsList = ingredientsList;
        MealPrice = mealPrice;
    }
}
