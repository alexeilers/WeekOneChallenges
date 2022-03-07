namespace KomodoCafeRepo;

public class MenuOptionsRepository {
    protected readonly List<MenuOptions> _contentDirectory = new List<MenuOptions>();
    

    public bool AddContentToDirectory(MenuOptions content){
        int startingCount = _contentDirectory.Count;

        _contentDirectory.Add(content);

        bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
        return wasAdded;
    }

    public bool DeleteExistingContent(MenuOptions existingContent){
    bool deleteResult = _contentDirectory.Remove(existingContent);
    return deleteResult; 
    }

    public List<MenuOptions> GetContents(){
        return _contentDirectory;
    }

    public MenuOptions GetContentByNumber(string mealName){
        foreach (MenuOptions content in _contentDirectory){
            if(content.MealName.ToLower() == mealName.ToLower()){
                return content;
            }
        }
        return null;

}

}