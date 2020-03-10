using System;
using System.Collections.Generic;
using System.Text;

namespace GroupDnD
{
    class Rouge : Character

    {

        public Rouge(string characterName, double hitPoints, int strength, int dex, int intelligence, int armor, Arsenal weapon, Arsenal weaknessMod, bool IsAlive, bool IsPlayer, int attackMod)
            : base(characterName, hitPoints, strength, dex, intelligence, armor, weaknessMod, IsAlive, IsPlayer, attackMod)
        {
            this.Job = "Rouge";
            this.Weapon = weapon;
            this.IsPlayer = true;
        }
        //public override string ToString()
        //{
        //    return $"Player: {CharacterName,10} | " + base.ToString();
        //}
    }
}
