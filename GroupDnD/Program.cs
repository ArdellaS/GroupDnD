using System;
using System.Collections.Generic;

namespace GroupDnD
{
    class Program
    {

        static void Main(string[] args)
        {
            CharacterList characterList = new CharacterList();

            string name = EnterName();
            int charSelection = SelectCharacter();

            characterList.ChooseJob(charSelection, name);
            characterList.RandomMonster();

            characterList.DisplayCharacterList();

            //Console.WriteLine("Please input 1 to use weapon: ");
            //int attackChoice = ValidateInput(0,1);

            while (characterList.ReturnList()[0].IsAlive)
            {
                Console.Clear();

                BattleDisplay.UI(characterList.ReturnList());
                BattleField.PlayerCombat(characterList.ReturnList());
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Press enter to continue"));
                Console.ReadLine();
                Console.Clear();
                BattleDisplay.UI(characterList.ReturnList());
                BattleField.EnemyCombat(characterList.ReturnList());
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Press enter to continue"));
                Console.ReadLine();



                if (!characterList.ReturnList()[characterList.ReturnList().Count - 1].IsAlive)
                {
                    characterList.RandomMonster();
                    Console.WriteLine($"A new {characterList.ReturnList()[characterList.ReturnList().Count - 1].Job} has joined the fray!\n");

                }

            }

        }
        public static int ValidateInput(int x, int y)
        {
            int input;
            bool worked;
            do
            {
                worked = int.TryParse(Console.ReadLine(), out input);
                if (!worked || input > x || input <= y)
                {
                    Console.WriteLine("Sorry, this is not a valid input. Please try again.");
                    worked = false;
                }
            } while (!worked);
            return input;
        }
        static int SelectCharacter()
        {
            bool worked;
            int characterChoice;
            Console.Write("Please select your character\n1: Warrior\n2: Rougue\n3: Mage\n >> ");

            do
            {
                worked = int.TryParse(Console.ReadLine(), out characterChoice);
                if (!worked || characterChoice > 3 || characterChoice <= 0)
                {
                    Console.WriteLine("Sorry, this is not a valid input. Please try again.");
                    worked = false;
                }
            } while (!worked);
            return characterChoice;
        }
        static string EnterName()
        {
            Console.Write("Please enter your name:\n >> ");
            return Console.ReadLine();
        }
    }
}
