using System;
using System.Collections.Generic;
using System.Text;

namespace GroupDnD
{
    public static class BattleField
    {
        public static void PlayerCombat(List<Character> characters)
        {
            double dmgDealt;

            if (Hit(characters[characters.Count - 1].AttackMod, characters[characters.Count - 1].Armor) == true)
            {
                dmgDealt = Damage(characters[0].Weapon, characters[characters.Count - 1].WeaknessMod, characters[0].AttackMod);

                characters[characters.Count - 1].HitPoints -= dmgDealt;
                Console.Clear();
                BattleDisplay.UI(characters);
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", $"{characters[0].CharacterName,40}'s {characters[0].Weapon} hit {characters[characters.Count - 1].Job} dealing {dmgDealt} damage!\n"));
                
                characters[characters.Count - 1].IsAlive = Death(characters[characters.Count - 1].HitPoints);

            }
            else
            {
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", $"{characters[0].CharacterName,40} missed with their {characters[0].Weapon}\n"));

            }
        }
        public static void EnemyCombat(List<Character> characters)
        {
            double dmgDealt;

            if (Hit(characters[0].AttackMod, characters[0].Armor) == true)
            {
                dmgDealt = Damage(characters[characters.Count - 1].Weapon, characters[0].WeaknessMod, characters[characters.Count - 1].AttackMod);

                characters[0].HitPoints -= dmgDealt;
                Console.Clear();
                BattleDisplay.UI(characters);

                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", $"{characters[characters.Count - 1].Job,40}'s {characters[characters.Count - 1].Weapon} hit {characters[0].CharacterName} dealing {dmgDealt} damage!\n"));

                characters[0].IsAlive = Death(characters[0].HitPoints);

            }
            else
            {
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", $"{characters[characters.Count - 1].Job,40} missed with their {characters[characters.Count - 1].Weapon}\n"));
}
        }
        public static bool Hit(int attackMod, int Armor)
        {
            int hitRoll = Dice.D20() + attackMod;
            if (hitRoll >= Armor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static double Damage(Arsenal weapon, Arsenal weaknessMod, int attackMod)
        {
            double damage;
            if (weapon == Arsenal.GreatSword || weapon == Arsenal.Rock)
            {
                damage = Dice.D4() + attackMod;
            }
            else if (weapon == Arsenal.Dagger || weapon == Arsenal.Club)
            {
                damage = Dice.D6() + attackMod;
            }
            else if (weapon == Arsenal.Staff || weapon == Arsenal.Claw)
            {
                damage = Dice.D8() + attackMod;
            }
            else
            {
                Console.WriteLine("This weapon does not exist");
                damage = 0;
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
