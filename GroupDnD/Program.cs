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

            string name = EnterName();
            int charSelection = SelectCharacter();

            characterList.ChooseJob(charSelection, name);
            Console.WriteLine($"Hello, {characterList.ReturnList()[0].CharacterName}. You have selected a {characterList.ReturnList()[0].Job}. \n");
            characterList.RandomMonster();
            Console.WriteLine($"A {characterList.ReturnList()[1].Job} approaches for a fight!\n\nPress enter to start the fight!");
            Console.ReadLine();
            Console.Clear();
            //characterList.DisplayCharacterList();
            BattleDisplay.UI(characterList.ReturnList());
            Console.WriteLine("Press enter to attack");
            Console.ReadLine();
            //Console.WriteLine("Please input 1 to use weapon: ");
            //int attackChoice = ValidateInput(0,1);

            while (characterList.ReturnList()[0].IsAlive)
            {
                Console.Clear();

                BattleDisplay.UI(characterList.ReturnList());
                BattleField.PlayerCombat(characterList.ReturnList());
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
                BattleDisplay.UI(characterList.ReturnList());
                BattleField.EnemyCombat(characterList.ReturnList());
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();



                if (!characterList.ReturnList()[characterList.ReturnList().Count - 1].IsAlive)
                {
                    characterList.RandomMonster();
                    Console.WriteLine($"A new {characterList.ReturnList()[characterList.ReturnList().Count - 1].Job} has joined the fray!\n");

                }

            }
            Console.WriteLine("YOU DIED! GAME OVER!");
            BattleDisplay.DisplayDead(characterList.ReturnList());
            Console.ReadLine();

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
            Console.Write("Please select your character\n1: Warrior\n2: Rogue\n3: Mage\n >> ");

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
