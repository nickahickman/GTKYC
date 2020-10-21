using System;
using System.Linq;

namespace ProjectLibrary
{
    public class GTKYC
    {
        public static void GetToKnowYourClassmates(string[,] students)
        {
            while (true)
            {
                MyLibs.ConsoleLibrary.DrawTitle("Get to Know Your Classmates");

                PrintStudentRoster(students);
                int targetStudent = int.Parse(MyLibs.UserInputLibrary.GetUserResponse($"Enter the ID of the student you want to know more about 0 - {students.GetLength(0) - 1}"));

                while (!StudentExists(students, targetStudent))
                { 
                    targetStudent = int.Parse(MyLibs.UserInputLibrary.GetUserResponse($"Student not found. Enter the ID of the student you want to know more about 0 - {students.GetLength(0) - 1}"));
                }

                string userQuery = MyLibs.UserInputLibrary.GetUserResponse($"Do you want to know {GetStudentName(students, targetStudent)}'s favorite food or hometown?");
                while (userQuery != "hometown" && userQuery != "favorite food")
                {
                    userQuery = MyLibs.UserInputLibrary.GetUserResponse($"I can only tell you about {GetStudentName(students, targetStudent)}'s favorite food or hometown. Which would you like to know?");
                }

                if (userQuery == "favorite food")
                {
                    Console.WriteLine($"{GetStudentName(students, targetStudent)}'s favorite food is {GetStudentFood(students, targetStudent)}");
                }
                else
                {
                    Console.WriteLine($"{GetStudentName(students, targetStudent)}'s hometown is {GetStudentHometown(students, targetStudent)}");
                }
                
                if (!MyLibs.UserInputLibrary.UserWantsToContinue("Would you like information on another student?", "I didn't understand that."))
                {
                    Console.WriteLine("Thanks, see you next time!");
                    break;
                }

                Console.Clear();
            }
        }
        public static void PrintStudentRoster(string[,] students)
        {
            int rosterSize = students.GetLength(0);

            MyLibs.ConsoleLibrary.DrawTitle("Current roster");

            for (int i = 0; i < rosterSize; i++)
            {
                Console.WriteLine($"{students[i, 0]} - Student ID: {i}");
            }

        }
        public static string GetStudentName(string[,] students, int index)
        {
            return students[index, 0];
        }
        public static string GetStudentFood(string[,] students, int index)
        {
            return students[index, 1];
        }
        public static string GetStudentHometown(string[,] students, int index)
        {
            return students[index, 2];
        }
        public static bool StudentExists(string[,] students, int studentIndex)
        {
            return studentIndex >= 0 &&  studentIndex < students.GetLength(0);
        }
    }
}
