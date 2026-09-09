using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PROGRAMMING
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LOGO logo = new LOGO();
            logo.displayLogo();

            // Play startup audio (wav)
            SoundPlayer player = new SoundPlayer(@"C:\Users\Student\source\repos\PROGRAMMING\PROGRAMMING\voice\Recording.wav");
            player.PlaySync();

            // Small pause before UI
            Thread.Sleep(200);

            // Top banner
            DrawSectionHeader("WELCOME");

            TypeWrite("Hello, World!", ConsoleColor.Cyan);
            TypeWrite("Welcome to the interactive console demo.", ConsoleColor.DarkCyan);
            Thread.Sleep(250);

            // Input section
            DrawDivider();
            response.DrawDivider();
            Console.WriteLine("Please enter your name ?");
            string userInput = Console.ReadLine();
            response.TypeWrite($"Hello, {userInput}!", ConsoleColor.Green);
            Thread.Sleep(150);

            string userFeeling = ReadInputWithDefault("How are you doing today", "okay");
            TypeWrite($"You are feeling {userFeeling} today.", ConsoleColor.Yellow);
            Thread.Sleep(150);

            string userPurpose = ReadInputWithDefault("What's your purpose", "learning");
            TypeWrite($"Your purpose is {userPurpose}.", ConsoleColor.Magenta);
            Thread.Sleep(150);

            string userQuestion = ReadInputWithDefault("What can you ask about", "anything");
            TypeWrite($"You can ask about {userQuestion}.", ConsoleColor.Green);
            Thread.Sleep(150);

            DrawDivider();
            TypeWrite("Thank you for using this demo. Press any key to exit...", ConsoleColor.DarkGray);
            Console.CursorVisible = false;
            Console.ReadKey(true);
        }

        private static void DrawSectionHeader(string title)
        {
            ConsoleColor headerColor = ConsoleColor.DarkBlue;
            ConsoleColor accentColor = ConsoleColor.White;
            WriteColoredLine("╔" + new string('═', 50) + "╗", headerColor);
            WriteColoredLine($"║ {title.PadRight(48)} ║", accentColor, headerColor);
            WriteColoredLine("╚" + new string('═', 50) + "╝", headerColor);
            Console.WriteLine();
            Thread.Sleep(150);
        }

        private static void DrawDivider()
        {
            ConsoleColor dividerColor = ConsoleColor.DarkGray;
            WriteColoredLine(new string('─', 54), dividerColor);
            Console.WriteLine();
            Thread.Sleep(100);
        }

        // Typing effect writer with optional color.
        private static void TypeWrite(string text, ConsoleColor? color = null, int charDelayMs = 20)
        {
            ConsoleColor previous = Console.ForegroundColor;
            if (color.HasValue) Console.ForegroundColor = color.Value;

            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(charDelayMs);
            }

            Console.WriteLine();
            Console.ForegroundColor = previous;
        }

        // Read input, accept default on empty/whitespace input and show a short message.
        private static string ReadInputWithDefault(string prompt, string defaultResponse)
        {
            ConsoleColor promptColor = ConsoleColor.White;
            ConsoleColor hintColor = ConsoleColor.DarkGray;
            ConsoleColor noticeColor = ConsoleColor.Red;

            // Write prompt and show default hint
            Console.ForegroundColor = promptColor;
            Console.Write($"{prompt} ");
            Console.ForegroundColor = hintColor;
            Console.Write($"(default: {defaultResponse})");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("> ");
            Console.CursorVisible = true;

            string? input = Console.ReadLine()?.Trim();
            Console.CursorVisible = false;

            if (string.IsNullOrEmpty(input))
            {
                Console.ForegroundColor = noticeColor;
                Console.WriteLine($"No input entered. Defaulting to '{defaultResponse}'.");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(200);
                return defaultResponse;
            }

            return input;
        }

        // Helper to print a full line in a color and reset background if desired.
        private static void WriteColoredLine(string text, ConsoleColor foreground, ConsoleColor? background = null)
        {
            ConsoleColor prevFore = Console.ForegroundColor;
            ConsoleColor prevBack = Console.BackgroundColor;

            Console.ForegroundColor = foreground;
            if (background.HasValue) Console.BackgroundColor = background.Value;

            Console.WriteLine(text);

            Console.ForegroundColor = prevFore;
            Console.BackgroundColor = prevBack;
        }
    }
}
