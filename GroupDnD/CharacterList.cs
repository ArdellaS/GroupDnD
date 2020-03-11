using System;
using System.Collections.Generic;
using System.Text;

namespace GroupDnD
{
    public class CharacterList
    {
        public static List<Character> characters = new List<Character>(); // list of heros

        string name, job;
        int strength, dexterity, intelligence, armor;
        Arsenal weakenesMod = Arsenal.None;
        int basePlayerHP = 25;
        int baseMonHP = 15;
        int warriorArmor = 14;
        int rogueArmor = 12;
        int mageArmor = 10;

        public void ChooseJob(int x, string name) //precondition has to be one of these options, we must check the input before we pass the int into this method
        {
            StatRoll();
            if (x == 1)
            {
                characters.Add(new Warrior(name, basePlayerHP + Dice.D8(), strength + 2, dexterity, intelligence, warriorArmor, Arsenal.GreatSword, weakenesMod, true, true, strength - 10));
                BattleDisplay.DisplayWarrior();
            }
            else if (x == 2)
            {
                characters.Add(new Rogue(name, basePlayerHP + Dice.D6(), strength, dexterity + 2, intelligence, rogueArmor, Arsenal.Dagger, weakenesMod, true, true, dexterity - 10));
                BattleDisplay.DisplayRogue();
            }
            else if (x == 3)
            {
                characters.Add(new Mage(name, basePlayerHP + Dice.D4(), strength, dexterity, intelligence + 2, mageArmor, Arsenal.Staff, weakenesMod, true, true, intelligence - 10));
                BattleDisplay.DisplayMage();
            }
        }
        public void RandomMonster() //precondition has to be one of these options, we must check the input before we pass the int into this method
        {
            int x = Dice.D3();
            StatRoll();

            if (x == 1)
            {
                characters.Add(new Troll(name, baseMonHP + Dice.D6(), strength, dexterity, intelligence, warriorArmor, Arsenal.Rock, Arsenal.GreatSword, true, false, strength - 10));
            }
            else if (x == 2)
            {
                characters.Add(new Goblin(name, baseMonHP + Dice.D4(), strength, dexterity, intelligence, rogueArmor, Arsenal.Club, Arsenal.Dagger, true, false, dexterity - 10));
            }
            else if (x == 3)
            {
                characters.Add(new Dragon(name, baseMonHP + Dice.D8(), strength, dexterity, intelligence, mageArmor, Arsenal.Claw, Arsenal.Staff, true, false, intelligence - 10));
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
        //public void DisplayCharacterList()
        //{
        //    foreach (Character c in characters)
        //    {
        //        Console.WriteLine(c);
        //    }
        //}
        public List<Character> ReturnList()
        {
            return characters;
        }

    }
}