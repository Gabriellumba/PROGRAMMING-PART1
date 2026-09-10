using System;
using System.Threading;

namespace PROGRAMMING
{
    class Response
    {
        public void DrawSectionHeader(string title)
        {
            ConsoleColor headerColor = ConsoleColor.DarkBlue;
            ConsoleColor accentColor = ConsoleColor.White;
            WriteColoredLine("╔" + new string('═', 50) + "╗", headerColor);
            WriteColoredLine($"║ {title.PadRight(48)} ║", accentColor, headerColor);
            WriteColoredLine("╚" + new string('═', 50) + "╝", headerColor);
            Console.WriteLine();
            Thread.Sleep(150);
        }

        public void DrawDivider()
        {
            ConsoleColor dividerColor = ConsoleColor.DarkGray;
            WriteColoredLine(new string('─', 54), dividerColor);
            Console.WriteLine();
            Thread.Sleep(100);
        }

        // Typing effect writer with optional color
        public void TypeWrite(string text, ConsoleColor? color = null, int charDelayMs = 20)
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

        // Read input with fallback default response
        public string ReadInputWithDefault(string prompt, string defaultResponse)
        {
            ConsoleColor promptColor = ConsoleColor.White;
            ConsoleColor hintColor = ConsoleColor.DarkGray;
            ConsoleColor noticeColor = ConsoleColor.Red;

            Console.ForegroundColor = promptColor;
            Console.Write($"{prompt} ");
            Console.ForegroundColor = hintColor;
            Console.Write("default: " + defaultResponse);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("User:  ");
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

        // Print full line with explicit colors
        public void WriteColoredLine(string text, ConsoleColor foreground, ConsoleColor? background = null)
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
