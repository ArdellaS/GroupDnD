using System;
using System.Collections.Generic;
using System.Text;



namespace FinalTime
{
    public class CharacterList
    {
        List<Character> characters = new List<Character>(); // list of heros

        string name, job;
        int strength, dexterity, intelligence, armor;
        Arsenal weakenesMod = Arsenal.None;
        int baseHP = 10;
        int warriorArmor = 16;
        int rougeArmor = 14;
        int mageArmor = 12;

        public void Name(string x)
        {
            name = x;
        }
        public void ChooseJob(int x) //precondition has to be one of these options, we must check the input before we pass the int into this method
        {
            StatRoll();
            if (x == 1)
            {
                characters.Add(new Warrior(name, baseHP + Dice.D8(), strength, dexterity, intelligence, warriorArmor, Arsenal.GreatSword, weakenesMod, true, true));
            }
            else if (x == 2)
            {
                characters.Add(new Rouge(name, baseHP + Dice.D6(), strength, dexterity, intelligence, rougeArmor, Arsenal.Dagger, weakenesMod, true, true));
            }
            else if (x == 3)
            {
                characters.Add(new Mage(name, baseHP + Dice.D4(), strength, dexterity, intelligence, mageArmor, Arsenal.Staff, weakenesMod, true, true));
            }
        }
        public void RandomMonster() //precondition has to be one of these options, we must check the input before we pass the int into this method
        {
            int x = Dice.D3();
            StatRoll();

            if (x == 1)
            {
                characters.Add(new Troll(name, baseHP + Dice.D6(), strength, dexterity, intelligence, warriorArmor, Arsenal.Rock, Arsenal.GreatSword, true, false));
            }
            else if (x == 2)
            {
                characters.Add(new Goblin(name, baseHP + Dice.D4(), strength, dexterity, intelligence, rougeArmor, Arsenal.Club, Arsenal.Dagger, true, false));
            }
            else if (x == 3)
            {
                characters.Add(new Dragon(name, baseHP + Dice.D8(), strength, dexterity, intelligence, mageArmor, Arsenal.Claw, Arsenal.Staff, true, false));
            }
        }

        public void StatRoll()
        {
            int x = Dice.D20();
            if (x <= 10)
            {
                strength = 10;
            }
            else
            {
                strength = x;
            }
            x = Dice.D20();
            if (x <= 10)
            {
                dexterity = 10;
            }
            else
            {
                dexterity = x;
            }
            x = Dice.D20();
            if (x <= 10)
            {
                intelligence = 10;
            }
            else
            {
                intelligence = x;
            }

        }

        public void DisplayCharacterList()
        {
            foreach (Character c in characters)
            {
                Console.WriteLine(c);
            }
        }
    }
}