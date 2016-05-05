using System;
using System.Collections.Generic;

namespace No_More_Ramen.Data
{
    public class Recipe
    {
        private string Name { get; set; }
        private int TimeToCookInMins { get; set; }
        private IList<Ingredient> Ingredients { get; set; }
        private IList<string> StepsToCook { get; set; }
        private DateTime DateAdded { get; } = DateTime.Now;

        public Recipe(string name, int timeTocook, IList<Ingredient> ingredients, IList<string> steps)
        {
            Name = name;
            TimeToCookInMins = timeTocook;
            Ingredients = ingredients;
            StepsToCook = steps;
        }  
    }
}
