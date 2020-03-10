using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTime
{
    class BattleField
    {
        public bool Hit(int weaknessMod, int Armor)
        {
            int hitRoll = Dice.D20() + weaknessMod;
            if (hitRoll >= Armor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public double Damage(Arsenal weapon, Arsenal weaknessMod, int baseStat)
        {
            double damage;
            if (weapon == Arsenal.GreatSword || weapon == Arsenal.Rock)
            {
                damage = Dice.D4() + baseStat;
            }
            else if (weapon == Arsenal.Dagger || weapon == Arsenal.Club)
            {
                damage = Dice.D6() + baseStat;
            }
            else if(weapon == Arsenal.Staff || weapon == Arsenal.Claw)
            {
                damage = Dice.D8() + baseStat;
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

        public bool Death(int hitPoints)
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
