using System;

namespace Lab8_GTKYC
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] students = { { "Mozart", "Pizza", "Salzburg" },
                                   { "Beethoven", "Hot Dogs", "Bonn" },
                                   { "Bach", "Steak", "Eisenach" },
                                   { "Chopin", "Offal", "Zelazowa Wola" },
                                   { "Handel", "Cheese", "Halle" } };

            ProjectLibrary.GTKYC.GetToKnowYourClassmates(students);
        }
    }
}
