using System;

internal class Soup
{
    public Soup(Ingredient[] ingredients)
    {
        foreach (var ingredient in ingredients)
        {
            if (ingredient is Meat && !(ingredient as Meat).IsTasty)
            {
                WillEat = false;
                return;
            }
            if (ingredient is Vegetable && (ingredient as Vegetable).IsAllergicTo)
            {
                WillEat = false;
                return;
            }
        }
        WillEat = true;
    }
    public bool WillEat { get; }
}