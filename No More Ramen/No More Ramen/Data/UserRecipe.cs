using System.Collections.ObjectModel;
namespace No_More_Ramen.Data
{
    public class UserRecipe
    {
        public UserData User { get; set; }
        public ObservableCollection<Recipe> Recipes { get; set; }

        public UserRecipe(UserData user, ObservableCollection<Recipe> recipes)
        {
            User = user;
            Recipes = recipes;
        } 
    }
}
