using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using No_More_Ramen.Data;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace No_More_Ramen
{
    public sealed partial class AddNewRecipe
    {
        private ObservableCollection<Recipe> _recipes;
        private UserData _usr;
        public AddNewRecipe()
        {
            InitializeComponent();
            Loaded += AddNewRecipeLoaded_Async;
        }

        private async void AddNewRecipeLoaded_Async(object sender, RoutedEventArgs e)
        {
            var folder = ApplicationData.Current.LocalFolder;
            StorageFile file = null;
            try
            {
                file = await folder.GetFileAsync("recipes.txt");
            }
            catch (FileNotFoundException)
            {
                file = await folder.CreateFileAsync("recipes.txt");
            }
            finally
            {
                LoadRecipes(file);
            }
        }

        private async void LoadRecipes(IStorageFile fileOfRecipes)
        {
            using (var reader = await fileOfRecipes.OpenReadAsync())
            {
                if (reader.Size <= 0) return;
                var serializer = new DataContractSerializer(typeof(ObservableCollection<Recipe>));
                _recipes =
                    (ObservableCollection<Recipe>)serializer.ReadObject(XmlReader.Create(reader.AsStreamForRead()));
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
             var usrData = e.Parameter as UserRecipe;
            if (usrData?.User != null)
                _usr = usrData.User;
            if (usrData?.Recipes != null)
                _recipes = usrData.Recipes;
        }

        private async void SubmitRecipe_OnClick(object sender, RoutedEventArgs e)
        {
            var recipe = VerifyFieldsAreCompleteAndReturnRecipe();
            if (recipe == null)
            {
                var md = new MessageDialog("All fields are required");
                await md.ShowAsync();
                return;
            }
            if(_recipes == null)
                _recipes = new ObservableCollection<Recipe>();
            _recipes.Add(recipe);
            var folder = ApplicationData.Current.LocalFolder;
            SaveNewRecipes_Async(folder);
            Frame.Navigate(typeof (PersonalScreen), new UserRecipe(_usr,_recipes));
        }

        private async void SaveNewRecipes_Async(IStorageFolder localAppFolder)
        {
            var file = await localAppFolder.CreateFileAsync("recipes.txt",
               CreationCollisionOption.ReplaceExisting);
            using (var reader = await file.OpenStreamForWriteAsync())
            {
                var serializer = new DataContractSerializer(typeof(ObservableCollection<Recipe>));
                serializer.WriteObject(reader, _recipes);

            }
        }

        private Recipe VerifyFieldsAreCompleteAndReturnRecipe()
        {
            var name = RecipeName.Text;
            int timeToCook;
            try
            {
                timeToCook = Int32.Parse(TimeToCook.Text);
            }
            catch (Exception)
            {

                return null;
            }
            if (name.Length <= 0)
                return null;
            if (timeToCook <= 0)
                return null;
            if (IngridientList.Text.Length <= 0)
                return null;
            if (StepsToCook.Text.Length <= 0)
                return null;
            var ingridients = IngridientList.Text.Split(',');
            var steps = StepsToCook.Text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            var recipe = new Recipe
            {
                Name = name,
                TimeToCookInMins =  timeToCook,
                Ingredients = ingridients,
                StepsToCook = steps,
                UserName = _usr?.UserName
            };
            return recipe;
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            if(Frame.CanGoBack)
                Frame.GoBack();
        }
    }
}
