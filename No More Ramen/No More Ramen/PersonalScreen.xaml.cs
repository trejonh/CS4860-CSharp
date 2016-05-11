using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using No_More_Ramen.Data;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace No_More_Ramen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PersonalScreen
    {
        private ObservableCollection<Recipe> _recipes;
        private UserData _usr; 
        public PersonalScreen()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
            DataContext = this;
        }

        protected  override void OnNavigatedTo(NavigationEventArgs e)
        {
            var combo = e.Parameter as UserRecipe;
            _recipes=combo?.Recipes;
            _usr = combo?.User;
            var curUserRecipes = _recipes?.Where(recipe => recipe.UserName == _usr.UserName).ToList();
            RecipeListBox.DataContext = curUserRecipes;
        }

        private void AddNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (AddNewRecipe), new UserRecipe(_usr,_recipes));
        }

        private void ViewAll_Click(object sender, RoutedEventArgs e)
        {
            RecipeListBox.DataContext = _recipes;
        }
    }
}
