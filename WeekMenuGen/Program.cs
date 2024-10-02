using System.Collections.Generic;
using WeekMenuGen;
public static class Program
{
    public static void Main(string[] args)
    {
        Product[][] OverallDishedMenuByTimeOfUse = new Product[3][];

        OverallDishedMenuByTimeOfUse[0] = new[] { new Product("omelette", new[] { "eggs", "milk" }), new Product("milkshake", new[] { "milk", "cinder", "bananas" }) };
        //breakfast
        OverallDishedMenuByTimeOfUse[1] = new[] { new Product("soup", new[] { "chicken", "potato" }), new Product("roastedChicken", new[] { "chicken", "carrot" }) };
        //lunch
        OverallDishedMenuByTimeOfUse[2] = new[] { new Product("bucketwheat With Milk", new[] { "bucketwheat", "milk" }), new Product("carrot pie", new[] { "flour", "carrot", "milk" }) };
        //dinner

        Product[][] ThisWeekMenu = new Product[3][];
        for (int i = 0; i < ThisWeekMenu.Length; i++) 
            ThisWeekMenu[i] = Product.GetRandomSevenDishes(OverallDishedMenuByTimeOfUse[i]);

        Product.PrintFoodTable(ThisWeekMenu, new string[]{ "завтрак", "обед", "ужин"});
        Product.ShowIngrideientList(ThisWeekMenu);
        
    }



    
}
