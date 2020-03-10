using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTime
{
    class Rouge : Character

    {
        private Arsenal weapon;

        public Arsenal Weapon { get => weapon; set => weapon = value; }

        public Rouge(string characterName, int hitPoints, int strength, int dex, int intelligence, int armor, Arsenal weapon, Arsenal weaknessMod, bool IsAlive, bool IsPlayer)
            : base(characterName, hitPoints, strength, dex, intelligence, armor, weaknessMod, IsAlive, IsPlayer)
        {
            this.Job = "Rouge";
            this.Weapon = weapon;
            this.IsPlayer = true;
        }
    }
}
