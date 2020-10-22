using System;
using System.Text.RegularExpressions;

namespace MyLibs
{
    public class UserInputLibrary
    {
        public static string GetUserResponse(string prompt)
        {
            string userResponse;

            Console.WriteLine(prompt);
            userResponse = Console.ReadLine().Trim();

            while (String.IsNullOrEmpty(userResponse))
            {
                Console.WriteLine("I need you to enter something. Silence isn't a virtue here!");
                userResponse = GetUserResponse(prompt);
            }

            return userResponse;
        }

        public static bool UserWantsToContinue(string originalQuery, string failResponse)
        {
            string userResponse = GetUserResponse($"{originalQuery}? (y/n)").ToLower(); ;

            while (userResponse != "n" && userResponse != "y")
            {
                userResponse = GetUserResponse($"{failResponse} {originalQuery} (y/n)").ToLower();
            }

            if (userResponse == "n")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class ConsoleLibrary
    {
        public static void DrawTitle(string title)
        {
            Console.WriteLine(title);
            DrawSeparator(title.Length);
        }
        public static void DrawSeparator(int stringLength)
        {
            string separator = new string('-', stringLength);
            Console.WriteLine($"{separator}");
        }
    }
}
