using System;
using System.Collections.Generic;
using System.Text;

namespace GroupDnD
{
    public class BattleDisplay
    {
        public static void UI(List<Character> characters)
        {
            LineBreak();
            HealthBar(characters);
            LineBreak();
            Console.WriteLine("\n\n\n");
            LineBreak();
            StatBar(characters);
        }
        public static void HealthBar(List<Character> characters)
        {
            Console.Write($"{characters[0].CharacterName,-30}{"",50}{characters[characters.Count-1].Job,30}\n");
            Console.Write($"{characters[0].HitPoints,-30}{"",50}{characters[characters.Count-1].HitPoints,30}\n");
            Console.Write($"{PlayerBar(characters),-30}{"",50}{EnemyBar(characters),30}\n");
        }
        public static void StatBar(List<Character> characters)
        {
            Console.Write($"{"Job: " + characters[0].Job,-30}{"",50}{"Job: " + characters[characters.Count - 1].Job,30}\n");
            Console.Write($"{"Str: " + characters[0].Strength,-30}{"",50}{"Str: " + characters[characters.Count - 1].Strength,30}\n");
            Console.Write($"{"Dex: " + characters[0].Dex,-30}{"",50}{"Dex: " + characters[characters.Count - 1].Dex,30}\n");
            Console.Write($"{"Int: " + characters[0].Intelligence,-30}{"",50}{"Int: " + characters[characters.Count - 1].Intelligence,30}\n");
            Console.Write($"{"Weak To: " + characters[0].WeaknessMod,-30}{"",50}{"Weak To: " + characters[characters.Count - 1].WeaknessMod,30}\n\n");

        }
        public static void LineBreak()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
        public static string PlayerBar(List<Character> characters)
        {
            string bar = "";
            for (int j = 0; j < characters[0].HitPoints; j++)
            {
                bar += "=";
            }

            return bar;
        }
        public static string EnemyBar(List<Character> characters)
        {
            string bar = "";
            for (int j = 0; j < characters[characters.Count - 1].HitPoints; j++)
            {
                bar += "=";
            }

            return bar;
        }

        public void DisplayDragon()
        {


        }
    }
}
