using System;
using System.Collections.Generic;
using System.Text;

namespace No_More_Ramen.Data
{
    public class Recipe
    {
        public string Name { get; set; }
        public int TimeToCookInMins { get; set; }
        public IList<string> Ingredients { get; set; }
        public IList<string> StepsToCook { get; set; }
        public string UserName { get; set; }
        public DateTime DateAdded { get; } = DateTime.Now;

        public override string ToString()
        {
            var recipe = new StringBuilder();
            recipe.Append(Name);
            recipe.AppendLine();
            recipe.Append("By " + UserName + " created at " + DateAdded.ToString());
            recipe.AppendLine().Append("Ingridients:").AppendLine();
            foreach (var i in Ingredients)
            {
                recipe.Append(i).AppendLine();
            }
            recipe.Append("Steps:").AppendLine();
            foreach (var i in StepsToCook)
            {
                recipe.Append(i).AppendLine();
            }
            return recipe.ToString();
        }
    }
}
