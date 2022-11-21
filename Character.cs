using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
namespace CharacterCreation
{
    public class Character
    {
        // the method for showing that the player was hit and seeing if they are still alive
        static public void Injure(int damage, ref int maxlife, ref bool isAlive)
        {
            Console.Write("Direct hit!");
            maxlife -= damage;
            if (maxlife <= 0)
            {
                Console.Write("Death");
                isAlive = false;
            }
        }
        // the method for getting how much damage the player will do
        static public int Damage(int strength)
        {
            int damage = strength;
            return damage;
        }
        // the mthod to show the players stats throughout the game.
        static public void Observe(bool isAlive, int strength, int dexterity, int maxLife)
        {
            var description = new StringBuilder();

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
    }
}