using System;

namespace Lab8_GTKYC
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] students = { { "Mozart", "Pizza", "Salzburg", "Fox" },
                                   { "Beethoven", "Hot Dogs", "Bonn", "Wolf" },
                                   { "Bach", "Steak", "Eisenach", "Ostrich" },
                                   { "Chopin", "Offal", "Zelazowa Wola", "Shark" },
                                   { "Handel", "Cheese", "Halle", "Bear" } };

            ProjectLibrary.GTKYC.GetToKnowYourClassmates(students);
        }
    }
}
