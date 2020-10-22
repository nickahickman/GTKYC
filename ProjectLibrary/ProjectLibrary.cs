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
                MyLibs.ConsoleLibrary.DrawTitle("Get to Know Your Classmates", "program");

                PrintStudentRoster(students);

                string studentID = MyLibs.UserInputLibrary.GetUserResponse($"Enter the ID of the student you want to know more about 0 - {students.GetLength(0) - 1}");
                while (!IsValidInteger(studentID))
                {
                    studentID = MyLibs.UserInputLibrary.GetUserResponse($"Invalid entry: Enter the ID of the student you want to know more about 0 - {students.GetLength(0) - 1}");
                }
                int targetStudent = int.Parse(studentID);

                while (!StudentExists(students, targetStudent))
                { 
                    targetStudent = int.Parse(MyLibs.UserInputLibrary.GetUserResponse($"Student not found. Enter the ID of the student you want to know more about 0 - {students.GetLength(0) - 1}"));
                }

                string userQuery = MyLibs.UserInputLibrary.GetUserResponse($"Do you want to know {GetStudentName(students, targetStudent)}'s favorite food, hometown, or favorite animal?");
                while (userQuery != "hometown" && userQuery != "favorite food" && userQuery != "favorite animal")
                {
                    userQuery = MyLibs.UserInputLibrary.GetUserResponse($"I can only tell you about {GetStudentName(students, targetStudent)}'s favorite food, hometown, or favorite animal. Which would you like to know?");
                }

                Console.WriteLine(GetStudentFact(students, targetStudent, userQuery));
                
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

            MyLibs.ConsoleLibrary.DrawTitle("Current roster", "section");

            for (int i = 0; i < rosterSize; i++)
            {
                Console.WriteLine($"ID: {i} - {GetStudentName(students, i)}");
            }
            Console.WriteLine("");
        }

        public static string GetStudentName(string[,] students, int index)
        {
            return students[index, 0];
        }

        public static string GetStudentFact(string[,] students, int index, string query)
        {
            if (query == "favorite food")
            {
                return $"{GetStudentName(students, index)}'s favorite food is {students[index, 1]}";
            }
            else if (query == "hometown")
            {
                return $"{GetStudentName(students, index)}'s hometown is {students[index, 2]}";
            }
            else
            {
                return $"{GetStudentName(students, index)}'s favorite animal is {students[index, 3]}";
            }
        }

        public static bool StudentExists(string[,] students, int studentIndex)
        {
            return studentIndex >= 0 &&  studentIndex < students.GetLength(0);
        }

        public static bool IsValidInteger(string userResponse)
        {
            return userResponse.All(Char.IsDigit);
        }
    }
}
