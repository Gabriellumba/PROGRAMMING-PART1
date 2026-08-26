using System;
using System.Collections.Generic;
using System.Media;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PROGRAMMING
{
    internal class Program
    {
        static void Main(string[] args)
        //  wav  extention for audio file 

        {
            LOGO logo = new LOGO();
            logo.displayLogo();

            SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\Student\source\repos\PROGRAMMING\PROGRAMMING\voice\Recording.wav");

            player.PlaySync();
            Console.WriteLine("Hello, World!");
            Console.WriteLine("welcome111");

            string userInput = Console.ReadLine();

        }
    }
}
