using System;
using System.IO;
using System.Media;
using System.Threading;

namespace PROGRAMMING
{
    class Program
    {
        static void Main(string[] args)
        {
            LOGO logo = new LOGO();
            logo.displayLogo();

            Response response = new Response();

            // Safe audio player initialization
            string audioPath = @"C:\Users\Student\source\repos\PROGRAMMING\PROGRAMMING\voice\Recording.wav";
            if (File.Exists(audioPath))
            {
                try
                {
                    SoundPlayer player = new SoundPlayer(audioPath);
                    player.PlaySync();
                }
                catch
                {
                    // Fallback when sound playback fails
                }
            }

            Thread.Sleep(200);

            // Display main app banner
            response.DrawSectionHeader("CYBERSECURITY AWARENESS BOT");

            response.TypeWrite("Hello! Welcome to the Cybersecurity Awareness Assistant.", ConsoleColor.Cyan);
            Thread.Sleep(250);

            // Initial User Info Prompt
            response.DrawDivider();
            response.TypeWrite("Please enter your name:", ConsoleColor.Yellow);
            Console.Write("User: ");
            Console.CursorVisible = true;
            string userName = Console.ReadLine()?.Trim();
            Console.CursorVisible = false;

            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = "User";
            }

            response.TypeWrite($"\nWelcome, {userName}!", ConsoleColor.Green);
            Thread.Sleep(150);

            // Introductory context queries
            string userFeeling = response.ReadInputWithDefault("How are you doing today?", "Good");
            response.TypeWrite($"Bot: Glad to hear you are feeling '{userFeeling}', {userName}.\n", ConsoleColor.Yellow);

            string userPurpose = response.ReadInputWithDefault("What brings you here today?", "Learning about online safety");
            response.TypeWrite($"Bot: Excellent! Focusing on '{userPurpose}' is a great goal.\n", ConsoleColor.Magenta);

            string userQuestion = response.ReadInputWithDefault("What topic would you like to start with?", "Passwords");
            response.TypeWrite($"Bot: You can ask about '{userQuestion}' or topics like phishing and safe browsing.\n", ConsoleColor.Green);

            // Main interaction loop
            bool isRunning = true;
            while (isRunning)
            {
                response.DrawDivider();

                response.TypeWrite("Ask a question (or type 'exit' to quit):", ConsoleColor.White);
                Console.Write("User: ");
                Console.CursorVisible = true;
                string userQuery = Console.ReadLine()?.Trim().ToLower() ?? "";
                Console.CursorVisible = false;

                if (string.IsNullOrEmpty(userQuery))
                {
                    response.TypeWrite("Bot: You didn't ask a question. Please try again.", ConsoleColor.Red);
                    Thread.Sleep(150);
                    continue;
                }

                if (userQuery == "exit" || userQuery == "quit")
                {
                    response.TypeWrite($"\nExiting the program. Stay safe online, {userName}!", ConsoleColor.DarkGray);
                    Thread.Sleep(250);
                    isRunning = false;
                    break;
                }

                // Topic Responses
                if (userQuery.Contains("password"))
                {
                    response.TypeWrite("Bot: Password Security: Use at least 12 characters combining letters, numbers, and symbols. Avoid personal dates or simple patterns!", ConsoleColor.Cyan);
                }
                else if (userQuery.Contains("phish") || userQuery.Contains("email"))
                {
                    response.TypeWrite("Bot: Phishing Prevention: Be cautious of emails demanding urgent action. Never click suspicious links or enter login details on unfamiliar pages.", ConsoleColor.Cyan);
                }
                else if (userQuery.Contains("browse") || userQuery.Contains("link") || userQuery.Contains("web"))
                {
                    response.TypeWrite("Bot: Safe Browsing: Check that website URLs start with 'https://' and look for the padlock icon before sharing sensitive info.", ConsoleColor.Cyan);
                }
                else if (userQuery.Contains("purpose") || userQuery.Contains("who are you"))
                {
                    response.TypeWrite("Bot: I am a Cybersecurity Awareness Assistant designed to help protect South African citizens against online threats.", ConsoleColor.Cyan);
                }
                else
                {
                    response.TypeWrite($"Bot: I didn't quite understand that, {userName}. Try asking about 'passwords', 'phishing', or 'safe browsing'.", ConsoleColor.Red);
                }

                Thread.Sleep(150);
            }

            response.DrawDivider();
            response.TypeWrite("Press any key to close this window...", ConsoleColor.DarkGray);
            Console.ReadKey(true);
        }
    }
}
