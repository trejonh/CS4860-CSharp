namespace No_More_Ramen.Data
{
    public class Ingredient
    {
        private string ItemName { get; set; }
        private string AmountToAdd { get; set; }

        public Ingredient(string name, string amount)
        {
            ItemName = name;
            AmountToAdd = amount;
        }
    }
}
