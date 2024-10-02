using System;
using System.Collections.Generic;




namespace WeekMenuGen
{
    internal class Product
    {
        public string ProductName { get; set; }
        public string[] Ingredients { get; set; }
        public Product(string productName, string[] ingredients)
        {
            ProductName = productName;
            Ingredients = ingredients;
        }

        public static Product[] GetRandomSevenDishes(Product[] productMassive) //Возвращает 7 случайных блюд из массива предложенных
        {
            Random rnd = new Random();
            int length = productMassive.Length;
            Product[] productRandomed = new[] { productMassive[rnd.Next(length)], productMassive[rnd.Next(length)], productMassive[rnd.Next(length)], productMassive[rnd.Next(length)],
        productMassive[rnd.Next(length)], productMassive[rnd.Next(length)], productMassive[rnd.Next(length)],};
            return productRandomed;
        }

        public static void PrintFoodTable(Product[][] SetOfDishes, string[] comments)
        //выводит таблицу 7х3, [дни недели] х [3 комментария]  на вход нужно 
        {
            Console.WriteLine("\tпн\tвт\tср\tчт\tпт\tсб\tвс");
            if (comments.Length != 3) throw new Exception("Wrong amount of comments"); //Должно быть 3 комментария

            if (SetOfDishes.GetUpperBound(0) != 2) throw new Exception("Wrong amount of FoodSets"); //Должно быть 3 набора блюд

            for (int i = 0; i < 3; i++) PrintSevenDishes(SetOfDishes[i], comments[i]);

            static void PrintSevenDishes(Product[] Dishes, string comment)
            {
                if (Dishes.Length != 7)
                    throw new Exception("Wrong amount of Food in set"); //Должно быть 7 блюд в наборе

                Console.Write(comment + "\t");
                for (int i = 0; i < 7; i++)
                    Console.Write($"{Dishes[i].ProductName}\t\t");
                Console.WriteLine(); //Очень некрасивый вывод
            }
        }

        static string[][] GetIndgridientsForEachDay(Product[][] ThisWeekMenu) //Возвращает Массив неповторяющихся ингридиентов на каждый день
        {
            if (ThisWeekMenu.GetUpperBound(0) != 2)
                throw new Exception("Wrong amount of Foodsets"); //Должно быть 3 набора блюд
            for (int i = 0; i < ThisWeekMenu.Length; i++)
                if (ThisWeekMenu[i].Length != 7)
                    throw new Exception("Wrong amount of Food in set"); //На каждое время должно быть 7 блюд

            string[][] eachDayIndgridients = new string[7][];
            for (int day = 0; day < 7; day++)
            {
                int lenOfIngridientsWithRepeats = 0;
                for (int timeOfDay = 0; timeOfDay < 3; timeOfDay++)
                {
                    lenOfIngridientsWithRepeats += ThisWeekMenu[timeOfDay][day].Ingredients.Length;
                }
                string[] eachDayIndgridientsWithRepeats = new string[lenOfIngridientsWithRepeats];
                int indexOfeachDayIndgridientsWithRepeats = 0;
                for (int timeOfDay = 0; timeOfDay < 3; timeOfDay++)
                {
                    for (int indexOfIngridient = 0; indexOfIngridient < ThisWeekMenu[timeOfDay][day].Ingredients.Length; indexOfIngridient++)
                    {
                        eachDayIndgridientsWithRepeats[indexOfeachDayIndgridientsWithRepeats] = ThisWeekMenu[timeOfDay][day].Ingredients[indexOfIngridient];
                        indexOfeachDayIndgridientsWithRepeats++;
                    }
                }
                eachDayIndgridients[day] = eachDayIndgridientsWithRepeats.Distinct().ToArray();
            }
            return eachDayIndgridients;
        }
        public static void ShowIngrideientList(Product[][] ThisWeekMenu) //Выводит ингридиенты в консоль
        {
            string[][] indgridientsForEachDay = GetIndgridientsForEachDay(ThisWeekMenu);

            for (int day = 0; day < 7; day++)
            {
                Console.Write($"[{day + 1}]: ");
                foreach (string ingridient in indgridientsForEachDay[day])
                    Console.Write($"{ingridient}, ");
                Console.WriteLine();
            }
        }
    }
}
