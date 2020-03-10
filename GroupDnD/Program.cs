using System;

namespace FinalTime
{
    class Program
    {
        
        static void Main(string[] args)
        {
            CharacterList characterList = new CharacterList();
            characterList.ChooseJob(SelectCharacter());

        }

        static int SelectCharacter()
        {
            bool worked;
            int characterChoice;
            Console.WriteLine("Please select your character");
            Console.WriteLine("1: Warrior");
            Console.WriteLine("2: Rouge");
            Console.WriteLine("3: Mage");
            do
            {
                worked = int.TryParse(Console.ReadLine(), out characterChoice);
                if (!worked || characterChoice > 3 || characterChoice <= 0 )
                {
                    Console.WriteLine("Sorry, this is not a valid input. Please try again.");
                    worked = false;
                }
            } while (!worked);
            return characterChoice;
        }
    }
}
