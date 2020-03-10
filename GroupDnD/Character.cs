using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTime
{
    abstract class Character
    {
        public string CharacterName { get; set; }
        public string Job { get; set; }
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Dex { get; set; }
        public int Intelligence { get; set; }
        public int Armor { get; set; }
        public Arsenal WeaknessMod { get; set; }
        public bool Status { get; set; }
        public bool IsPlayer { get; set; }

        public Character(string characterName, int hitPoints, int strength, int dex, int intelligence, int armor, Arsenal weaknessMod, bool IsAlive, bool IsPlayer)
        {
            CharacterName = characterName;
            HitPoints = hitPoints;
            Strength = strength;
            Dex = dex;
            Intelligence = intelligence;
            Armor = armor;
            WeaknessMod = weaknessMod;
            IsAlive = true;
            IsPlayer = false;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
