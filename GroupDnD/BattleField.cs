using System;
using System.Collections.Generic;
using System.Text;

namespace GroupDnD
{
    public static class BattleField
    {
        static int hitRoll = 0;
        static int attackDice = 0;
        public static void PlayerCombat(List<Character> characters)
        {
            double dmgDealt;

            if (Hit(characters[characters.Count - 1].AttackMod, characters[characters.Count - 1].Armor, out hitRoll) == true)
            {
                bool isCrit = false;
                dmgDealt = Damage(characters[0].Weapon, characters[characters.Count - 1].WeaknessMod, characters[0].AttackMod, out attackDice);
                if (hitRoll == 20)
                {
                    dmgDealt *= 2;
                    isCrit = true;
                }

                characters[characters.Count - 1].HitPoints -= dmgDealt;
                Console.Clear();
                BattleDisplay.UI(characters);
                if (isCrit == true)
                {
                    Console.WriteLine("\nCritical Hit! You have done double damage!\n");
                }
                Console.WriteLine($"{characters[0].CharacterName} rolled a {hitRoll} breaking enemy armor.\n" +
                    $"Second dice rolled a {attackDice} with a {characters[0].Weapon} and hit {characters[characters.Count - 1].Job} dealing {dmgDealt} damage!\n");
                
                characters[characters.Count - 1].IsAlive = Death(characters[characters.Count - 1].HitPoints);

            }
            else
            {
                Console.WriteLine($"{characters[0].CharacterName} rolled a {hitRoll} and missed with their {characters[0].Weapon}\n");
            }
        }
        public static void EnemyCombat(List<Character> characters)
        {
            double dmgDealt;

            if (Hit(characters[0].AttackMod, characters[0].Armor, out hitRoll) == true)
            {
                bool isCrit = false;
                dmgDealt = Damage(characters[characters.Count - 1].Weapon, characters[0].WeaknessMod, characters[characters.Count - 1].AttackMod, out attackDice);
                if (hitRoll == 20)
                {
                    dmgDealt *= 2;
                    isCrit = true;
                }

                characters[0].HitPoints -= dmgDealt;

                Console.Clear();
                BattleDisplay.UI(characters);
                if (isCrit == true)
                {
                    Console.WriteLine("\nCritical Hit! You have done double damage!\n");
                }
                Console.WriteLine($"{characters[characters.Count - 1].Job} rolled a {hitRoll} breaking through your armor." +
                    $"Second dice rolled a {attackDice} with a {characters[characters.Count - 1].Weapon} and hit {characters[0].CharacterName} dealing {dmgDealt} damage!\n");

                characters[0].IsAlive = Death(characters[0].HitPoints);

            }
            else
            {
                Console.WriteLine($"{characters[characters.Count - 1].Job} rolled a {hitRoll} and missed with their {characters[characters.Count - 1].Weapon}\n");
}
        }
        public static bool Hit(int attackMod, int Armor, out int hitRoll)
        {
            hitRoll = Dice.D20();
            int totalRoll = hitRoll + attackMod;
            if (totalRoll >= Armor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static double Damage(Arsenal weapon, Arsenal weaknessMod, int attackMod, out int attackDice)
        {
            double damage;
            if (weapon == Arsenal.GreatSword || weapon == Arsenal.Rock)
            {
                attackDice = Dice.D4();
                damage = attackDice + attackMod;
            }
            else if (weapon == Arsenal.Dagger || weapon == Arsenal.Club)
            {
                attackDice = Dice.D6();
                damage = attackDice + attackMod;
            }
            else if (weapon == Arsenal.Staff || weapon == Arsenal.Claw)
            {
                attackDice = Dice.D8();
                damage = attackDice + attackMod;
            }
            else
            {
                Console.WriteLine("This weapon does not exist");
                damage = 0;
                attackDice = 0;
            }
            if (weaknessMod == weapon)
            {
                damage = damage * 1.25;
            }
            return damage;
        }

        public static bool Death(double hitPoints)
        {
            if (hitPoints <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
