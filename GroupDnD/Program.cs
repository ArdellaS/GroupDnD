using System;
using System.Collections.Generic;

namespace GroupDnD
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.SetWindowSize(140, 45);
            
            CharacterList characterList = new CharacterList();

            do
            {
             Console.Clear();
             characterList.ReturnList().Clear();
            string name = EnterName();
            int charSelection = SelectCharacter();

            characterList.ChooseJob(charSelection, name);
            Console.WriteLine($"Hello, {characterList.ReturnList()[0].CharacterName}. You have selected a {characterList.ReturnList()[0].Job}. \n");
            characterList.RandomMonster();
            Console.WriteLine($"A {characterList.ReturnList()[1].Job} approaches for a fight!\n\nPress enter to start the fight!");
            Console.ReadLine();
            Console.Clear();
            BattleDisplay.UI(characterList.ReturnList());


            while (characterList.ReturnList()[0].IsAlive)
            {
                int attackSelection;
                Console.Clear();

                BattleDisplay.UI(characterList.ReturnList());
                Console.WriteLine("Please Select your attack 1-2 \n1: Light Attack \n2: Heavy Attack");
                attackSelection = ValidateInput(0,2);
                BattleField.PlayerCombat(characterList.ReturnList(), attackSelection);
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
                BattleDisplay.UI(characterList.ReturnList());
                if (characterList.ReturnList()[characterList.ReturnList().Count - 1].IsAlive)
                {
                    BattleField.EnemyCombat(characterList.ReturnList());
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
                else
                {
                    characterList.RandomMonster();
                    Console.WriteLine($"A new {characterList.ReturnList()[characterList.ReturnList().Count - 1].Job} has joined the fray!\n");
                    BattleField.AddHealth(characterList.ReturnList());
                }
            }
            Console.WriteLine($"YOU DIED! GAME OVER!\nYou have defeated {characterList.ReturnList().Count - 2} monters!\n\n");
            BattleDisplay.DisplayDead(characterList.ReturnList());

            } while (Continue());
        }

        private static bool Continue()
        {
            char c;
            do
            {
                Console.WriteLine("Would you like to create a new adventurer and slay more monsters? Y/N");
                c = Console.ReadKey().KeyChar;
                if (c == 'n' || c == 'N')
                {
                    return false;
                }
            } while (c != 'y' && c != 'Y');

            return true;
        }

        public static int ValidateInput(int x, int y)
        {
            int input;
            bool worked;
            do
            {
                worked = int.TryParse(Console.ReadLine(), out input);
                if (!worked || input > y || input <= x)
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
            Console.Write("Please select your character: Enter 1-3\n1: Warrior\n2: Rogue\n3: Mage\n >> ");

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
