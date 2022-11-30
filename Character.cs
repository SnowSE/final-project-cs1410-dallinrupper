using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
namespace CharacterCreation
{
    public class Character
    {
        // the method for showing that the player was hit and seeing if they are still alive
        static public bool Injure(int damage, ref int maxlife, ref bool isAlive)
        {
            Console.WriteLine("Direct hit!");
            maxlife -= damage;
            Console.WriteLine($"HP left: {maxlife}");
            if (maxlife <= 0)
            {
                isAlive = false;
                return isAlive;
            }
            else
            {
                return isAlive;
            }
        }
        // the method for getting how much damage the player will do multiplied by his item.
        static public int DamageModified(int strength, Items item)
        {
            int weapon = (int)item;
            int damage = strength * weapon;
            return damage;
        }
        // the method to show the players stats throughout the game.
        static public void Observe(bool isAlive, int strength, int dexterity, int maxLife)
        {
            if (isAlive)
            {
                Console.WriteLine("Strength:" + strength);
                Console.WriteLine("Dexterity:" + dexterity);
                Console.WriteLine("MaxLife:" + maxLife);
            }
            else
            {
                Console.WriteLine("You are dead");
            }
        }
        public enum Items { Sword = 3, Knife = 2, Gun = 10, Sheild = 1, Rifle = 100 }

    }
}