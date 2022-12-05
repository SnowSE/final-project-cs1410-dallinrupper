using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using DiceThrower;
namespace CharacterCreation
{
    public class Character
    {
        // the method for showing that the player was hit and seeing if they are still alive
        static public bool Injure(int damage, ref int maxlife, bool isAlive)
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
        public enum Items { Sword = 3, Knife = 2, Gun = 4, Sheild = 1, Rifle = 5 }

        public static (int, int, int) rollForCharacter()
        {
            while (true)
            {

                var roll = Console.ReadLine();
                if (roll == "r")
                {
                    var character = CharacterCreation.CharacterFactory.Generate();
                    return character;
                }
                else
                {
                    Console.WriteLine("Please enter r to roll.");
                }
            }

        }

        // Method for rolling to see if the players attack succeeds or fails.
        public static bool rollForAttackEasy(bool isAlive, int strength, int dexterity, int maxLife)
        {
            while (true)
            {

                var roll = Console.ReadLine();
                if (roll == "r")
                {
                    int attackChance = Dice.Throw100();
                    if (attackChance < 25)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }
                else if (roll == "o")
                {
                    Observe(isAlive, strength, dexterity, maxLife);
                    Console.WriteLine("Press 'r' to roll or press 'o' to see your stats again.");
                }
                else
                {
                    Console.WriteLine("Please enter 'r' to roll or press 'o' to see your stats.");
                }
            }

        }
    }
}