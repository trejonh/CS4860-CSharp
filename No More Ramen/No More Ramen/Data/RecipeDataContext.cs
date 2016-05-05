using System.ComponentModel;
using System.Data.Linq;
namespace No_More_Ramen.Data
{
    public class RecipeDataContext : DataContext
    {
        public RecipeDataContext(string connection) : base(connection)
        {
            
        }

        public Table<Recipe> Recipes;

        [Table]
        public class Recipe : INotifyPropertyChanged
        {
            private int _recipeId;
            [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert))]
            public int ToDoItemId
            {
                get { return _recipeId; }
                set
                {
                    if (_recipeId != value)
                    {
                        _recipeId = value;
                        NotifyPropertyChanged("RecipeId");
                    }
                }
            }
        }
    }
}
