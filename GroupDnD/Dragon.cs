using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTime
{
    class Dragon : Character

    {
        private Arsenal weapon;

        public Arsenal Weapon { get => weapon; set => weapon = value; }

        public Dragon(string characterName, int hitPoints, int strength, int dex, int intelligence, int armor, Arsenal weapon, Arsenal weaknessMod, bool IsAlive, bool IsPlayer)
            : base(characterName, hitPoints, strength, dex, intelligence, armor, weaknessMod, IsAlive, IsPlayer)
        {
            this.Job = "Dragon";
            this.Weapon = weapon;
            this.WeaknessMod = Arsenal.Staff;
        }
    }
}
